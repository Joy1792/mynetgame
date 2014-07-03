using UnityEngine;
using System.Collections;

public class WindowManager : MonoBehaviour {
	public GameObject windowPanel;
	void Start () 
	{
	
	}
	
	void Update () 
	{
		if(WindowConstans.windowList.Count>0)
		{
			int type = WindowConstans.windowList[0];
			OnWindow(type);
			WindowConstans.windowList.RemoveAt(0);
		}
	}
	public void OnWindow(int type)
	{
		switch(type)
		{
		case WindowConstans.INPUT_ERROR:
			windowPanel.BroadcastMessage("setMessage","Input error,reinput");
			break;
		default:
			windowPanel.BroadcastMessage("setMessage","unknow error");
			break;
		}
		windowPanel.SetActive(true);
	}
}
