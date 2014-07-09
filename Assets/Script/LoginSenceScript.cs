using UnityEngine;
using System.Collections;

public class LoginSenceScript : MonoBehaviour
{
	public GameObject regPanel;
	public UILabel usrLabel;
	public UILabel pwdLabel;
	public void RegistClick()
	{
		if (GameInfo.GAME_STATE == GameState.RUN)
		{
			GameInfo.GAME_STATE = GameState.USR_REG;
			regPanel.SetActive(true);
		}
	}
	public void LoginClick()
	{
		if(GameInfo.GAME_STATE != GameState.RUN)
		{
			WindowConstans.windowList.Add(WindowConstans.STATE_ERROR);
			return;
		}
		if(usrLabel.text != string.Empty && pwdLabel.text != string.Empty)
		{
			LoginDTO dto = new LoginDTO();
			dto.userName = usrLabel.text;
			dto.passWord = pwdLabel.text;
			string message = Coding<LoginDTO>.encode(dto);

			//send login message to server
			NetWorkScript.getInstance().sendMessage(Protocol.LOGIN,0,LoginProtocol.LOGIN_CREQ,message);
		}else
		{
			WindowConstans.windowList.Add(WindowConstans.INPUT_ERROR);
		}
	}

}
