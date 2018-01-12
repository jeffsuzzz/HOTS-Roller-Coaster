using UnityEngine;
using System.Collections;

public class Unit_MineBoss : MonoBehaviour {

	public GameObject target;

	private Animation anim;
	private bool flag;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> ();
		foreach(AnimationState state in anim){
			state.speed = 0.75F;
		}
		flag = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (flag) {
			Vector3 targetdir = target.transform.position- transform.position;
			float step = 2 * Time.deltaTime;
			Vector3 newdir = Vector3.RotateTowards (transform.forward, targetdir, step, 0.0f);
			transform.rotation = Quaternion.LookRotation (newdir);
		}
	}

	public void PlayerComes(){		
		StartCoroutine (Second());
	}

	IEnumerator Second(){
		yield return new WaitForSeconds (1);
		anim.PlayQueued ("Spell_Astart",  QueueMode.PlayNow);
		yield return new WaitForSeconds (2);
		flag = true;
		anim.PlayQueued ("Walk",  QueueMode.CompleteOthers);
		Destroy (gameObject, 10.0f);
	}
}
