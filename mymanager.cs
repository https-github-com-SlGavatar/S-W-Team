using System.Collectoins;
using System.Collectoins.Generic;
using UnityEngine;
using ArduinoBluetoothAPI;
using System;

public class mymanager  : MonoBehaviour{
	//use this for intialization 
	private BluetoothHelper  helper;
	private string deviceName;
	void start(){
		deviceName = "HC-06";
		try{
			helper.BluetoothHelper.GetInstance(deviceName);
			helper.OnConnected+= OnConnected;
			helper.OnConnectedFailed+=OnConnectedFailed;


			helper.SetTerminatorBasedStream("\n");
			//or
			//helper.SetLengthBasedStream
			if(helper.isDeviceFound){
				helper.Connect();

			}

		}catch(BluetoothHelper.BluetoothNotEnabledException ex){}
		catch(BluetoothHelper.BluetoothNotReadyException ex){}
		catch(BluetoothHelper.BluetoothNotSupportedException ex){}
		catch(BluetoothHelper.BluetoothPermissionNotGrantedException ex){}


	}
	void OnConnected(){
		helper.StartListening();
		helper.SendData("Hi Arduino!");		//This can be called anywhere


	}
	//update is called once per frame
	void update(){
		if(helper.Available){
			string msg = helper.Read();
		}

	}
	void OnDestroy(){
		helper.StopListening();
	}



}