using UnityEngine;
using System.Collections;

public class WindowManager : MonoBehaviour {
	public GameObject windowPanel;
	private WindowPanelScript script;
	void Start () 
	{
		script = windowPanel.GetComponent<WindowPanelScript>();
	}
	
	void Update () 
	{
		bool s = true;
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
			script.setMessage("Input error,reinput");
			//windowPanel.BroadcastMessage("setMessage","Input error,reinput");
			break;
		default:
			script.setMessage("unknow error");
			//windowPanel.BroadcastMessage("setMessage","unknow error");
			break;
		}
		windowPanel.SetActive(true);
	}
} 
 