import json
import pyodbc
import paho.mqtt.client as mqtt

def on_connect(client, userdata, flags, rc, properties):
    print(f"Connected to broker with result code {rc}")
    client.subscribe(TOPIC, qos=1)

def on_message(client, userdata, msg):
    print(f"Raw message received on topic: {msg.topic}")
    data = json.loads(msg.payload)
    cursor = userdata.cursor()
    cursor.execute(
        """
        INSERT INTO sensor_readings (machine_id, sensor, value, unit, anomaly, timestamp)
        VALUES (?, ?, ?, ?, ?, ?)
        """, 
        data["machine_id"], data["sensor"], data["value"],
        data["unit"], data["anomaly"], data["timestamp"])
    
    userdata.commit()
    print(f"Inserted: {data['machine_id']} / {data['sensor']} = {data['value']}")

BROKER = "localhost"
TOPIC = "factory/#"

CONN_STR = (
    "DRIVER={ODBC DRIVER 17 for SQL Server};"
    "SERVER=localhost;"
    "DATABASE=SensorData;"
    "Trusted_Connection=yes;"
)

conn = pyodbc.connect(CONN_STR)

client = mqtt.Client(mqtt.CallbackAPIVersion.VERSION2, userdata=conn)
client.on_connect = on_connect
client.on_message = on_message
client.connect(BROKER)

print("Ingestion service started. Waiting for messages...")
client.loop_forever()