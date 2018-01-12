using UnityEngine;
using System.Collections;

public class Hero_Thrall : MonoBehaviour {

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

	public void PlayerComes(){
		anim.PlayQueued ("Stun",  QueueMode.PlayNow);
	}
		
}
