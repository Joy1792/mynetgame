using UnityEngine;
using System.Collections;

public class RegPanelScript : MonoBehaviour {
	public UILabel username;
	public UILabel password;
	void Start () 
	{
		gameObject.SetActive(false);
	}
	void OkClick()
	{
		//if (username.text != string.Empty && password.text != string.Empty)
		//{
			//send regist message to server  
			//gameObject.SetActive(true); 
		//}
		gameObject.SetActive(false);
	}
	void CancelClick()
	{
		gameObject.SetActive(false);
	}
}
