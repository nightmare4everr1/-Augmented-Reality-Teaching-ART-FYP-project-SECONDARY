using UnityEngine;
using System.Collections;

public class NewBehaviourScript : Photon.MonoBehaviour {


	void Start () {
		
	}
	

	void Update ()
	{
		if( photonView.isMine == false && PhotonNetwork.connected == true )
		{
			return;
		}


	}

	void OnMouseDown()
	{
		
		Debug.Log ("YOU TOUCHED ME");
		this.photonView.RPC ("destroyme", PhotonTargets.All);
		network.index = network.index - 1;


	}

	[PunRPC]
	void destroyme()
	{
		Destroy (gameObject);
	}





	public void ONCLICKRIGHT(){
		
		Debug.Log ("I GOT CLICKED");
		Rigidbody objbody =  network.obj.GetComponent<Rigidbody>();
		objbody.AddForce (10*Vector3.right, ForceMode.Impulse);

	}
	public void ONCLICKLEFT(){

		Debug.Log ("I GOT CLICKED");
		Rigidbody objbody =  network.obj.GetComponent<Rigidbody>();
		objbody.AddForce (-10*Vector3.right, ForceMode.Impulse);

	}
	public void ONCLICKUP(){

		Debug.Log ("I GOT CLICKED");


		Rigidbody objbody =  network.obj.GetComponent<Rigidbody>();
		objbody.AddForce (10*Vector3.forward, ForceMode.Impulse);

	}
	public void ONCLICKDOWN(){

		Debug.Log ("I GOT CLICKED");
		Rigidbody objbody =  network.obj.GetComponent<Rigidbody>();
		objbody.AddForce (-10*Vector3.forward, ForceMode.Impulse);

	}


}
