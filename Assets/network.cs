using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class network : MonoBehaviour {
	public static GameObject obj;
	public static int index=0;
	public static GameObject obj_cyl=null;






	public GameObject[] obj2= new GameObject[5];


	[Tooltip("The prefab to use for representing the player")]
	public GameObject playerPrefab;
	public GameObject Cyl_Prefab;


	// Use this for initialization
	void Start () 
	{
		PhotonNetwork.ConnectUsingSettings ("v4.2");
		PhotonNetwork.sendRate = 40;
		PhotonNetwork.sendRateOnSerialize = 40;

	}
	
	// Update is called once per frame
	// Shows connection state on top left corner of screen
	void OnGUI ()
	{
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
	}

	void OnJoinedLobby()
	{
		Button mybutton;
		mybutton = GameObject.Find ("Button Host").GetComponent<Button> ();
		mybutton.interactable = true;
		Debug.Log ("JOINED LOBBY, create or join room now");

	}



	void OnJoinedRoom()
	{
		
		
		 if (playerPrefab == null)
		{
			Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'",this);
		} else 
		{
			Debug.Log("We are Instantiating LocalPlayer from "+Application.loadedLevelName);
			// we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
		
			obj = PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f,0f,10f), Quaternion.identity, 0) as GameObject;
	    }
	


	}

	//buttonGUI functions
	void Hidebuttons()
	{
		Button mybutton;
		Slider myslider;

		mybutton = GameObject.Find ("Button Reset").GetComponent<Button>();
		mybutton.interactable = false;
		mybutton = GameObject.Find ("Button Start").GetComponent<Button>();
		mybutton.interactable = false;

		myslider = GameObject.Find ("Slider(PivotDistance)").GetComponent<Slider> ();
		myslider.interactable = false;
		myslider = GameObject.Find ("Slider (Height)").GetComponent<Slider> ();
		myslider.interactable = false;
	}

	public void CreateRoom()
	{
		Text mytext = GameObject.Find ("Status").GetComponent<Text> ();
		mytext.text = "You are now Host";
		PhotonNetwork.CreateRoom ("myroom");
		Button mybutton;
		mybutton = GameObject.Find ("Button Join").GetComponent<Button> ();
		mybutton.interactable = false;
		mybutton = GameObject.Find ("Button Host").GetComponent<Button> ();
		mybutton.interactable = false;



	}
	public void JoinRoom()
	{
		Text mytext = GameObject.Find ("Status").GetComponent<Text> ();
		mytext.text = "You are now Client";
		PhotonNetwork.JoinRoom ("myroom");
		Hidebuttons ();
	}
	public void CREATE()
	{
		Debug.Log ("index is " + index);
		if (index >= 5) 
		{
			Debug.Log ("MAX CUBES REACHED");
			return;
		} 

		obj2[index] = PhotonNetwork.Instantiate (this.playerPrefab.name, new Vector3 (-10+5*index, 0f, -10f), Quaternion.identity, 0) as GameObject;
		index = index + 1;


	}
	public void RESET()
	{
		
	}

	public void CREATE_CYLINDER()
	{
		Debug.Log ("inside create cylinder function");
		if (obj_cyl == null) 
		{
			obj_cyl=PhotonNetwork.Instantiate(this.Cyl_Prefab.name, new Vector3(-5,0,0),Quaternion.identity,0) as GameObject;
		}
	}
}
