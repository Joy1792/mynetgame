using UnityEngine;
using System.Collections;

public class ConnServer : MonoBehaviour {

	public void OnClick()
	{
		Debug.Log("begin conn");
		NetWorkScript.getInstance();
	}

}
