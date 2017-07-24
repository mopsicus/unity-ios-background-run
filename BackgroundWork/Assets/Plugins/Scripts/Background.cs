using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class Background : MonoBehaviour {

	#if UNITY_IOS
		[DllImport ("__Internal")]
		private static extern void backgroundLaunch ();
		[DllImport ("__Internal")]
		private static extern void backgroundStop ();		
	#endif

	// Start background task
	public static void StartTask () {
		#if UNITY_EDITOR		
		#elif UNITY_IOS
			backgroundLaunch ();
		#endif
	}

	// Stop background task
	public static void StopTask () {
		#if UNITY_EDITOR				
		#elif UNITY_IOS
			backgroundStop ();
		#endif
	}	

}
