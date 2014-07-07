using UnityEngine;
using System.Collections;

public class LoginHandler : MonoBehaviour {

	void Start () 
	{
	}
	
	void Update () 
	{
	
	}
	public void OnMessage(SocketModel model)
	{
		Debug.Log("read message");
	}
}
