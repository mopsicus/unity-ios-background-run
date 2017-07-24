using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public class Demo : MonoBehaviour {

	void Start () {	
		TimerCallback timeCB = new TimerCallback(PrintTime);
        Timer time = new Timer(timeCB, null, 0, 1000);
	}

	void PrintTime (object state) {
		Debug.LogFormat ("Timer {0}", DateTime.Now.ToLongTimeString());
	}

	void OnApplicationFocus (bool focusStatus) {				
		if (focusStatus) 
			Background.StopTask();
		else 
			Background.StartTask();
	}	
}
