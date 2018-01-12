using UnityEngine;
using System.Collections;

public class Effect_Ragnaros_Core : MonoBehaviour {

	public GameObject target;

	private Animation anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> ();
		foreach(AnimationState state in anim){
			//state.speed = 0.75F;
		}
		StartCoroutine(NextAnim ());
	}
	
	// Update is called once per frame
	void Update () {
		float step = 5.0F * Time.deltaTime;

		Vector3 targetdir = target.transform.position - transform.position;
		targetdir.y = 0;
		Vector3 newdir = Vector3.RotateTowards (transform.forward, targetdir, step, 0.0f);
		transform.rotation = Quaternion.LookRotation (newdir);
	}
		
	IEnumerator NextAnim(){
		yield return new WaitForSeconds (1.5f);
		anim.PlayQueued ("Spell_A",  QueueMode.PlayNow);	
		yield return new WaitForSeconds (0.5f);
		anim.PlayQueued ("Death",  QueueMode.CompleteOthers);
	}

	public void SetTarget(GameObject t){
		target = t;
	}
}
