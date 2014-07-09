using UnityEngine;
using System.Collections;

public class RegPanelScript : MonoBehaviour {
	public UILabel usrname;
	public UILabel password;
	void Start () 
	{
		gameObject.SetActive(false);
	}
	public void OnClick()
	{
		if (GameInfo.GAME_STATE != GameState.USR_REG)
		{ 
			WindowConstans.windowList.Add(WindowConstans.STATE_ERROR);
			return;
		}

		if (usrname.text != string.Empty && password.text != string.Empty)
		{
			//send regist message to server 
			LoginDTO dto = new LoginDTO();
			dto.userName = usrname.text;
			dto.passWord = password.text;
			string message = Coding<LoginDTO>.encode(dto);
			NetWorkScript.getInstance().sendMessage(Protocol.LOGIN,0,LoginProtocol.REG_CREQ,message);
			gameObject.SetActive(false);
			GameInfo.GAME_STATE = GameState.RUN;
		} else
		{
			WindowConstans.windowList.Add(WindowConstans.INPUT_ERROR);
		}
		GameInfo.GAME_STATE = GameState.RUN;
		gameObject.SetActive(false);

	}
	public void CancelClick()
	{
		GameInfo.GAME_STATE = GameState.RUN;
		gameObject.SetActive(false);
	}
}
