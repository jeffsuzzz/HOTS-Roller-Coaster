using UnityEngine;
using System.Collections;

public class Effect_Arthas_Sindragosa : MonoBehaviour {

	public GameObject cone;
	public float speed;

	private Animation anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> ();
		foreach(AnimationState state in anim){
			state.speed = 0.75F;
		}
		transform.localScale = new Vector3 (20,20,20);
		anim.PlayQueued ("Stand", QueueMode.CompleteOthers);

		cone = transform.Find ("Mesh 2").gameObject;
		cone.GetComponent<Renderer> ().enabled = false;
		speed = 0.0f;
		StartCoroutine (FlyAway());
	}
	
	// Update is called once per frame
	void Update () {
		if (anim.IsPlaying("Stand")) {
			speed = 200F;
			cone.GetComponent<Renderer> ().enabled = true;
		}
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
	}

	IEnumerator FlyAway(){
		yield return new WaitForSeconds (4);
		anim.PlayQueued ("Death", QueueMode.PlayNow);
		cone.GetComponent<Renderer> ().enabled = false;
		speed = 0.0f;
	}

}
