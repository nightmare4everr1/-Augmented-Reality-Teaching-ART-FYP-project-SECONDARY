using UnityEngine;
using System.Collections;

public class seesaw : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RESET()
	{
		Transform TR = GetComponent<Transform> ();
		TR.eulerAngles = new Vector3(0,0,0);
	}
}
