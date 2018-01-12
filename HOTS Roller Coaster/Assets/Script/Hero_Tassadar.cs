using UnityEngine;
using System.Collections;

public class Hero_Tassadar : MonoBehaviour {

	public GameObject archon;
	public GameObject forcewall;

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
		StartCoroutine (Second());
	}

	IEnumerator Second(){
		//wait unitil Boss start  to attack, then force wall
		yield return new WaitForSeconds (2);
		anim.PlayQueued ("Spell_B", QueueMode.PlayNow);
		GameObject ForceWall;
		ForceWall = Instantiate (forcewall, new Vector3( 0, -200, 25) , Quaternion.Euler (0, -70, 0)) as GameObject;
		ForceWall.transform.localScale = new Vector3 (4,4,4);
		Destroy (ForceWall, 5.0f);

		//transform
		yield return new WaitForSeconds (1);
		anim.PlayQueued ("Spell_Cstart",  QueueMode.CompleteOthers);
		yield return new WaitForSeconds (0.8F);
		GameObject archonobj;
		archonobj = Instantiate (archon, transform.position , transform.rotation) as GameObject;
		archonobj.transform.localScale = new Vector3 (6,6,6);
		transform.Find ("Mesh 1").gameObject.GetComponent<Renderer> ().enabled = false;
		transform.Find ("Mesh 2").gameObject.GetComponent<Renderer> ().enabled = false;
		transform.Find ("Mesh 3").gameObject.GetComponent<Renderer> ().enabled = false;
		transform.Find ("Mesh 4").gameObject.GetComponent<Renderer> ().enabled = false;
		Destroy (gameObject, 10.0f);
	}
}
