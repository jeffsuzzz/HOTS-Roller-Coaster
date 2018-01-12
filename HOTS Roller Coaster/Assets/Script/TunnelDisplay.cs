using UnityEngine;
using System.Collections;

public class TunnelDisplay : MonoBehaviour {

	public Transform target;
	
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").transform;		
		foreach(Transform child in transform){
			child.gameObject.GetComponent<Renderer>().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void ChangeDisplay(){
		Renderer rend;
		foreach(Transform child in transform){
				rend = child.gameObject.GetComponent<Renderer>();
				rend.enabled = !rend.enabled;
			}
	}
	
}
