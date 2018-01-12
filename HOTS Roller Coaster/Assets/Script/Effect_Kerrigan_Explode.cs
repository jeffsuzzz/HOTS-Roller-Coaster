using UnityEngine;
using System.Collections;

public class Effect_Kerrigan_Explode : MonoBehaviour {

	private Vector3 scaletemp;
	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3 (20,20,20);
	}
	
	// Update is called once per frame
	void Update () {
		scaletemp = new Vector3(100,100,100) * Time.deltaTime;
		transform.localScale += scaletemp;
	}
}
