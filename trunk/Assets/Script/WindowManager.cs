using UnityEngine;
using System.Collections;

public class WindowManager : MonoBehaviour
{
	public GameObject windowPanel;
	private WindowPanelScript script;

	void Start()
	{
		script = windowPanel.GetComponent<WindowPanelScript>();
	}
	
	void Update()
	{
		if (WindowConstans.windowList.Count > 0)
		{
			int type = WindowConstans.windowList [0];
			OnWindow(type);
			//if(GameInfo.GAME_STATE != GameState.WINDOW)
			//{
			WindowConstans.windowList.RemoveAt(0);
			//}
		}

	}

	public void OnWindow(int type)
	{
		switch (type)
		{
			case WindowConstans.INPUT_ERROR:
				script.setMessage("Input error,reinput");
			//windowPanel.BroadcastMessage("setMessage","Input error,reinput");
				break;
			case WindowConstans.SOCKETA_TYPE_FAIL:
				script.setMessage("socket type error");
				break;
			case WindowConstans.USR_REG_OK:
				script.SendMessage("USR_REG_OK");
				break;
			case WindowConstans.USR_REG_FAIL:
				script.SendMessage("USR_REG_FAIL");
				break;
			default: 
				script.setMessage("unknow error");
			//windowPanel.BroadcastMessage("setMessage","unknow error");
				break;
		}
		windowPanel.SetActive(true);
	}
} 
 