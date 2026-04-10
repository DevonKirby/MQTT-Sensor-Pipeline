## MQTT Sensor Pipeline

A simulated industrial sensor monitoring system built across three components.

A **C++ simulator** generates fake sensor readings (temperature, pressure, vibration, humidity) for three machines and publishes them over MQTT every two seconds. About 5% of readings are intentionally anomalous to mimic real-world faults.

A **Python ingestion service** subscribes to those MQTT messages and writes each reading into a SQL Server database as it arrives.

A **C# WinForms dashboard** queries the database on a live refresh timer and displays the incoming data — a live readings table, an anomaly alert list, a per-sensor summary, and a scatter plot of the last 50 readings for any machine/sensor combination.

**Stack:** C++ / CMake / Paho MQTT · Python / paho-mqtt / pyodbc · C# .NET 8 / WinForms / ScottPlot / SQL Server
