from sense_hat import SenseHat

sense = SenseHat()

temp = sense.get_temperature()
print(temp)

pressure = sense.get_pressure()
print(pressure)

humidity = sense.get_humidity()
print(humidity)
