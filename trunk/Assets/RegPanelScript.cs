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
		if (GameInfo.GAME_STATE != GameState.USR_REG)
		{ 
			WindowConstans.windowList.Add(WindowConstans.STATE_ERROR);
			GameInfo.GAME_STATE = GameState.RUN;
			gameObject.SetActive(false);
			WindowConstans.windowList.Add(WindowConstans.STATE_ERROR);
			return;
		}

		if (username.text != string.Empty && password.text != string.Empty)
		{
			//send regist message to server 
		} else
		{
			WindowConstans.windowList.Add(WindowConstans.INPUT_ERROR);
		}

	}
	void CancelClick()
	{
		GameInfo.GAME_STATE = GameState.RUN;
		gameObject.SetActive(false);
	}
}
