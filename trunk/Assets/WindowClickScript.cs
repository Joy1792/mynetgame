using UnityEngine;
using System.Collections;

public class WindowClickScript : MonoBehaviour {
	public UILabel label;

	void Start () 
	{
		gameObject.SetActive(false);
	}
	public void setMessage(string value)
	{
		label.text = value;
	}
	public void OnClick()
	{
		gameObject.SetActive(false);
	}
}
