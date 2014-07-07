using UnityEngine;
using System.Collections;

public class RegPanelScript : MonoBehaviour {
	public UILabel usrname;
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

		if (usrname.text != string.Empty && password.text != string.Empty)
		{
			//send regist message to server 
			RegistDTO dto = new RegistDTO();
			dto.usrName = usrname.text;
			dto.passWord = password.text;
			string message = Coding<RegistDTO>.encode(dto);
			NetWorkScript.getInstance().sendMessage(Protocol.LOGIN,0,LoginProtocol.REG_CREQ,message);


			gameObject.SetActive(false);
			GameInfo.GAME_STATE = GameState.RUN;
		} else
		{
			WindowConstans.windowList.Add(WindowConstans.INPUT_ERROR);
			//GameInfo.GAME_STATE =GameState.WINDOW;
		}

	}
	void CancelClick()
	{
		GameInfo.GAME_STATE = GameState.RUN;
		gameObject.SetActive(false);
	}
}
