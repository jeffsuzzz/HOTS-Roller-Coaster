using UnityEngine;
using System.Collections;

public class Hero_Lucio : MonoBehaviour {

	public GameObject bumpdest;
	public GameObject finaldest;

	private bool start;
	private bool second;
	private Animation anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> ();
		foreach(AnimationState state in anim){
			state.speed = 0.75F;
		}
		start = false;
		second = false;
	}
	
	// Update is called once per frame
	void Update () {
		float step = 10.0F * Time.deltaTime;
		if (start && !second) {
			transform.position = Vector3.MoveTowards (transform.position, bumpdest.transform.position, step * 7);
		}
		else if(second){
			transform.position = Vector3.MoveTowards (transform.position, finaldest.transform.position, step * 7);
			Destroy (gameObject, 10.0f);
		}
		if (Vector3.Distance (bumpdest.transform.position, transform.position) < 5.0f) {
			second = true;
		}
	}

	public void PlayerComes(){		
		start = true;
		anim.PlayQueued ("Spell_A", QueueMode.PlayNow);
		StartCoroutine (Second());
	}
	IEnumerator Second(){
		yield return new WaitForSeconds (0.2f);
		anim.PlayQueued ("Spell_B", QueueMode.CompleteOthers);
	}

}
