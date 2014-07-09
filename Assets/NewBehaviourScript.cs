using UnityEngine;
using System.Collections;
using System;

public class NewBehaviourScript : MonoBehaviour
{
	public GameObject target;
	public string stringToEdit = "100";

	void Start()
	{
	}
	
	void Update()
	{
		try
		{
			target.transform.position = new Vector3(Convert.ToSingle(stringToEdit), 0, 0);
		} catch
		{
			Debug.Log("hehe");
		}
	}

	void OnGUI()
	{
		stringToEdit = GUI.TextArea(new Rect(10, 10, 200, 20), stringToEdit, 200);
	}

}
