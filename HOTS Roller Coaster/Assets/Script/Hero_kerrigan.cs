using UnityEngine;
using System.Collections;

public class Hero_kerrigan : MonoBehaviour {

	public GameObject maelstrom;
	private Animation anim;
	private ParticleSystem particle;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> ();
		/*foreach(AnimationState state in anim){
			state.speed = 0.75F;
		}*/
		anim ["taunt"].speed = 0.75f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayerComes(){
		anim.PlayQueued ("taunt",  QueueMode.PlayNow);
		StartCoroutine (PlayerAway());
	}

	IEnumerator PlayerAway(){
		yield return new WaitForSeconds (1);
		GameObject boom;
		Vector3 spawnPos = transform.position;
		spawnPos.y += 10;
		boom = Instantiate (maelstrom, spawnPos , transform.rotation) as GameObject;
		Destroy (boom, 1.5f);

		anim.PlayQueued ("Walk_alt",  QueueMode.CompleteOthers);
	}

}
