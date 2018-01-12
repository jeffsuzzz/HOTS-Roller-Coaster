using UnityEngine;
using System.Collections;

public class MountPick : MonoBehaviour {

	public float testnum;
	// Use this for initialization
	void Start () {
		transform.Find ("HearhStoneCard").gameObject.SetActive (false);
		transform.Find ("SnowFlake").gameObject.SetActive (false);

		if(ChooseMount.mountnum == 1){
			transform.Find ("HearhStoneCard").gameObject.SetActive (true);
		}
		else if(ChooseMount.mountnum == 2){
			transform.Find ("SnowFlake").gameObject.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
