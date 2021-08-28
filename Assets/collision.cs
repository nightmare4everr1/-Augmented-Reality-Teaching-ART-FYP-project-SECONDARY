using UnityEngine;
using System.Collections;

public class collision : MonoBehaviour {
	public static float velocityObj;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Rigidbody rb = GetComponent<Rigidbody> ();
		Debug.Log ("velocity = " + rb.velocity.magnitude);

		
	}




}
