using UnityEngine;
using System.Collections;

public class TunnelControl : MonoBehaviour {

	public GameObject tunnel;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(){
		tunnel.SendMessage("ChangeDisplay");
	}
}
