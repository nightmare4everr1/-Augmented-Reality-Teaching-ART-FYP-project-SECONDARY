using UnityEngine;
using System.Collections;

public class SourceW : MonoBehaviour {
	public float height = 61.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void START()
	{
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.isKinematic = false;
	}

	public void RESET()
	{
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.position = new Vector3 (-12f, height, 0f);
		transform.eulerAngles = new Vector3 (0, 0, 0);
		rb.isKinematic = true;
	}
	public void SetHeight(float newH)
	{
		height = newH;
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.position = new Vector3 (-12f, height, 0f);

	}
}

