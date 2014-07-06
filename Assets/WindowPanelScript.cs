using UnityEngine;
using System.Collections;

public class WindowPanelScript : MonoBehaviour {
	public UILabel label;

	void Start () 
	{
		gameObject.SetActive(false);
	}
	public void setMessage(string v)
	{
		label.text = v;
	}
	public void OnClick()
	{
		gameObject.SetActive(false);
	}
}
