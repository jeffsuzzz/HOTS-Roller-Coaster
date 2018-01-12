using UnityEngine;
using System.Collections;

public class Hero_Azmodan : MonoBehaviour {

	public GameObject fireballprefab;

	private Animation anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> ();
		foreach(AnimationState state in anim){
			state.speed = 0.75F;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//When player approach
	public void PlayerComes(){
		anim.PlayQueued ("Spell_A", QueueMode.PlayNow);

		GameObject fireball;
		Vector3 Flocation = transform.position;
		Flocation.y = 35;
		fireball = Instantiate (fireballprefab, Flocation , transform.rotation) as GameObject;
		Destroy (fireball, 3.0f);
	
		StartCoroutine (PlayerAway());
	}

	IEnumerator PlayerAway(){
		yield return new WaitForSeconds (1);
		anim.PlayQueued ("Attack",  QueueMode.CompleteOthers);
	}
}
