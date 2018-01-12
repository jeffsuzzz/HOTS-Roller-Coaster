using UnityEngine;
using System.Collections;

public class Hero_Tyrael : MonoBehaviour {

	public GameObject enemy;
	public GameObject flailpoint;

	private Animator animator;
	private bool flail;
	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
		flail = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (flail) {
			float step = 10.0F * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, flailpoint.transform.position, step * 8);
		}
	}

	public void PlayerComes(){		
		animator.SetBool("Flail", true);
		flail = true;
	}
}
