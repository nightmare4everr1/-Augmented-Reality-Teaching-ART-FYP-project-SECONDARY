using UnityEngine;
using System.Collections;

public class BigCube : Photon.MonoBehaviour {

	public float position=-100f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MOVECUBE(float newpos)
	{
		GameObject bigcube = GameObject.Find ("BigCube");
		bigcube.GetComponent<PhotonView> ().RequestOwnership ();
		position = newpos;
		this.photonView.RPC ("MOVEME", PhotonTargets.All);

	}
	[PunRPC]
	void MOVEME()
	{
		transform.position = new Vector3 (position,0f,0f);
	}


	public void RESET()
	{
		this.photonView.RPC ("RPCreset", PhotonTargets.All);

	}

	[PunRPC]
	void RPCreset()
	{
		MeshRenderer mesh = gameObject.GetComponent<MeshRenderer> ();
		mesh.enabled = true;
		gameObject.transform.position = new Vector3 (position, 0, 0);
	}
}
