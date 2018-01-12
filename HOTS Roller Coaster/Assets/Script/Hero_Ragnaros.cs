using UnityEngine;
using System.Collections;

public class Hero_Ragnaros : MonoBehaviour {

	public GameObject bigrag;
	public GameObject bigraglocation;
	public GameObject building;
	public GameObject target;

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
		anim.PlayQueued ("Spell_P",  QueueMode.PlayNow);	//channel
		StartCoroutine (PlayerAway());
	}

	IEnumerator PlayerAway(){
		yield return new WaitForSeconds (2);
		transform.Find ("Mesh 1").gameObject.GetComponent<Renderer> ().enabled = false;
		transform.Find ("Mesh 2").gameObject.GetComponent<Renderer> ().enabled = false;

		building.SetActive(false);

		GameObject ragCore;
		ragCore = Instantiate (bigrag, bigraglocation.transform.position , transform.rotation) as GameObject;
		ragCore.SendMessage ("SetTarget", target);
		Destroy (ragCore, 6.0f);
		yield return new WaitForSeconds (6.0f);
		building.SetActive(true);
	}


}
