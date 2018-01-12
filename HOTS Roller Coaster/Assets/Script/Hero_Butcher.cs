using UnityEngine;
using System.Collections;

public class Hero_Butcher : MonoBehaviour {

	public GameObject target;
	public float finaldist;
	public GameObject bumpdest;
	public GameObject finaldest;
	
	private Animator animator;
	private bool flag;
	private bool back;
	private Animation anim;
	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
		flag = false;
		back = false;
	}
	
	// Update is called once per frame
	void Update () {
		float step = 10.0F * Time.deltaTime;
		finaldist = Vector3.Distance(bumpdest.transform.position, transform.position);

		if (flag && finaldist > 10) {
			Vector3 targetdir = target.transform.position - transform.position;
			Vector3 newdir = Vector3.RotateTowards (transform.forward, targetdir, step, 0.0f);
			transform.rotation = Quaternion.LookRotation (newdir);
			transform.position = Vector3.MoveTowards (transform.position, bumpdest.transform.position, step * 8);
		} else if (finaldist < 10) {
			//hit back and taunt
			flag = false;
			back = true;
			animator.SetBool("Back", true);
		}
		if (back && Vector3.Distance(finaldest.transform.position, transform.position) > 10) {
			transform.position = Vector3.MoveTowards (transform.position, finaldest.transform.position, step *10 );
			Destroy (gameObject, 10.0f);
		}
	}

	//When player approach
	public void PlayerComes(){		
		animator.SetBool("Found", true);
		StartCoroutine (Second());
	}

	IEnumerator Second(){
		yield return new WaitForSeconds (0.3F);		
		flag = true;
	}
}
