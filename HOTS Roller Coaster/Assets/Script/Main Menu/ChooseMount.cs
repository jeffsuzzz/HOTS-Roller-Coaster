using UnityEngine;
using System.Collections;

public class ChooseMount : MonoBehaviour {

	static public float mountnum ;
	public float mm;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Chosen(){
		mountnum = mm;
		Application.LoadLevel("sceneBig");
	}

}
