using UnityEngine;
using System.Collections;

public class Hero_Arthas : MonoBehaviour {

	public GameObject Sindragosa;
	
	private Animation anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> ();
		foreach(AnimationState state in anim){
			//state.speed = 0.75F;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//When player approach
	public void PlayerComes(){
		anim.PlayQueued ("Spell_D",  QueueMode.PlayNow);
		GameObject icedragon;
		Vector3 spawnPos = transform.position;
		spawnPos -= transform.forward*100;
		spawnPos.y = 100;
		icedragon = Instantiate (Sindragosa, spawnPos , transform.rotation) as GameObject;
		Destroy (icedragon, 5.0f);

		StartCoroutine (PlayerAway());
	}

	IEnumerator PlayerAway(){
		yield return new WaitForSeconds (1);
		anim.PlayQueued ("Attack",  QueueMode.CompleteOthers);
		yield return new WaitForSeconds (2);
		anim.PlayQueued ("Taunt",  QueueMode.CompleteOthers);
	}
}
