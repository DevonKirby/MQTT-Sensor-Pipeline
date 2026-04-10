#include <iostream>
#include <string>
#include <vector>
#include <random>
#include <chrono>
#include <sstream>
#include <iomanip>
#include <ctime>
#include <thread>
#include <mqtt/client.h>

struct SensorConfig {
    std::string name;
    std::string unit;
    double normal_min;
    double normal_max;
    double anomaly_min;
    double anomaly_max;
};

struct Machine {
    std::string id;
    std::vector<SensorConfig> sensors;
};

double generateReading(const SensorConfig& sensor, std::mt19937& rng, bool& is_anomaly) {       // Generates random reading for a sensor
    std::uniform_real_distribution<double> probability(0.0, 1.0);
    is_anomaly = probability(rng) < 0.05;   // 5% chance of anomaly

    if (is_anomaly) {
        std::uniform_real_distribution<double> dist(sensor.anomaly_min, sensor.anomaly_max);
        return dist(rng);
    } else {
        std::uniform_real_distribution<double> dist(sensor.normal_min, sensor.normal_max);
        return dist(rng);
    }
}

std::string currentTimestamp() {
    auto now = std::chrono::system_clock::now();
    std::time_t t = std::chrono::system_clock::to_time_t(now);
    std::tm utc{};
    gmtime_s(&utc, &t);

    std::ostringstream ss;
    ss << std::put_time(&utc, "%Y-%m-%dT%H:%M:%SZ");
    return ss.str();
}

std::string buildPayload(const std::string& machine_id, const SensorConfig& sensor, double value, bool is_anomaly) {    // Generates JSON payload
    std::ostringstream ss;
    ss << std::fixed << std::setprecision(2);
    ss << "{"
       << "\"machine_id\":\"" << machine_id << "\","
       << "\"sensor\":\"" << sensor.name << "\","
       << "\"value\":" << value << ","
       << "\"unit\":\"" << sensor.unit << "\","
       << "\"anomaly\":" << (is_anomaly ? "true" : "false") << ","
       << "\"timestamp\":\"" << currentTimestamp() << "\""
       << "}";
    return ss.str();
}

int main() {
    std::cout << "Sensor Simulator starting..." << std::endl;

    mqtt::client client("tcp://localhost:1883", "sensor_simulator");
    client.connect();

    std::vector<Machine> machines = {
    { "machine_1", {
        { "temperature", "C",   60.0, 90.0,  105.0, 130.0 },
        { "pressure",    "PSI", 50.0, 150.0, 185.0, 220.0 },
        { "vibration",   "g",   0.5,  2.0,   5.0,   8.0   },
        { "humidity",    "%",   30.0, 60.0,  75.0,  95.0  }
    }},
    { "machine_2", {
        { "temperature", "C",   60.0, 90.0,  105.0, 130.0 },
        { "pressure",    "PSI", 50.0, 150.0, 185.0, 220.0 },
        { "vibration",   "g",   0.5,  2.0,   5.0,   8.0   },
        { "humidity",    "%",   30.0, 60.0,  75.0,  95.0  }
    }},
    { "machine_3", {
        { "temperature", "C",   60.0, 90.0,  105.0, 130.0 },
        { "pressure",    "PSI", 50.0, 150.0, 185.0, 220.0 },
        { "vibration",   "g",   0.5,  2.0,   5.0,   8.0   },
        { "humidity",    "%",   30.0, 60.0,  75.0,  95.0  }
    }}
    };

    std::mt19937 rng(std::chrono::steady_clock::now().time_since_epoch().count());  // Setting the seed to our rng

    while (true) {
        for (const auto& machine : machines) {
            for (const auto& sensor : machine.sensors) {
                bool is_anomaly = false;
                double value = generateReading(sensor, rng, is_anomaly);
                std::string topic = "factory/" + machine.id + "/" + sensor.name;
                std::string payload = buildPayload(machine.id, sensor, value, is_anomaly);

                auto msg = mqtt::make_message(topic, payload);
                msg->set_qos(1);
                client.publish(msg);

                std::cout << topic << " -> " << payload << "\n";
            }
        }
        std::this_thread::sleep_for(std::chrono::seconds(2));
    }

    client.disconnect();
    return 0;
}