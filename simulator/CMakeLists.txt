cmake_minimum_required(VERSION 3.15)
project(SensorSimulator)

set(CMAKE_CXX_STANDARD 17)

find_package(PahoMqttCpp CONFIG REQUIRED)

add_executable(SensorSimulator main.cpp)

target_link_libraries(SensorSimulator PRIVATE PahoMqttCpp::paho-mqttpp3-shared)