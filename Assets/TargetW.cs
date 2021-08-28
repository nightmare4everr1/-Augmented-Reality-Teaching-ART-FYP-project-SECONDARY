using UnityEngine;
using System.Collections;


public class TargetW : Photon.MonoBehaviour {

	public float position=3.6f;
	public Collision temp;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "BigCube") 
		{
			temp = col;
			this.photonView.RPC ("RPC_hide_cube", PhotonTargets.All);

		}
			
	}
	[PunRPC]
	void RPC_hide_cube()
	{
		MeshRenderer mesh= temp.gameObject.GetComponent<MeshRenderer>();
		mesh.enabled = false;
		temp.gameObject.transform.position = new Vector3 (0, -200, 0);
	}


	public void RESET()
	{
		
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.isKinematic = true;
		rb.position = new Vector3 (position, 11.5f, 0f);
		transform.eulerAngles = new Vector3 (0, 0, 0);


	}
	public void START()
	{
		

		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.isKinematic = false;
	}

	public void Position_on_SeeSaw(float newpos)
	{
		position = newpos;
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.position = new Vector3 (position, 11.5f, 0f);

	}

}
