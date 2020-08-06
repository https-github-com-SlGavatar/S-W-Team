void sendBT(const char *data, int l){
	byte len[4];
	len[0] = 85;  //preamable
	len[1] = 85;  //preamable
	len[2] = (l>>8) & 0x000000FF;
	len[3] = (l & 0x000000FF);
	Serial.write(len,4);
	Serial.flush();
	Serial.print(data);
	Serial.flush();
	
}