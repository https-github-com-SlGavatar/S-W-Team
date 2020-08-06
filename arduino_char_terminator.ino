void setup(){
	Serial.begin(9600);
}
void loop(){
	if (Serial.available() >0){
		Serial.print("You wrote: ");
		Serial.flush();

	while(Serial.available() >0){
		Serial.write(Serial.read());
		Serial.flush();				//this is a must for Arduino to wait until Serial.write is done
	}
	Serial.print("\n");
	Serial.flush();
	}
	delay(100);
	Serial.println("Send here any text ");

}