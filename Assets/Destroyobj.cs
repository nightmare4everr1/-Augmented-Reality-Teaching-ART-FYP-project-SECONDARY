using UnityEngine;
using System.Collections;

public class Destroyobj : MonoBehaviour {

	RaycastHit hit;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetMouseButton (0)) 
		{
			Vector3 mousePosFar = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
			Vector3 mousePosNear = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
			Vector3 mousePosF = Camera.main.ScreenToWorldPoint (mousePosFar);
			Vector3 MousePosN = Camera.main.ScreenToWorldPoint (mousePosNear);


			if(Physics.Raycast(MousePosN,mousePosF-MousePosN,out hit))
			{
				if (hit.transform.gameObject.name == "Plane") 
				{
					
				} 
				else 
				{
					PhotonView photonView = PhotonView.Get (this);
					photonView.RPC ("Destroy_obj2", PhotonTargets.All);
				}
			}

		}
	
	}

	[PunRPC]
	void Destroy_obj()
	{
		Destroy(hit.transform.gameObject);
	}
	[PunRPC]
	void Destroy_obj2()
	{
		
		Destroy(gameObject);
	}
}
