using UnityEngine;
using System.Collections;

public class LoginHandler : MonoBehaviour {

	public void OnMessage(SocketModel model) 
	{
		Debug.Log("read message");
		switch(model.command)
		{
			case LoginProtocol.REG_SRES:
				RegResult(model.message);
				break;
			case LoginProtocol.LOGIN_SRES:
				loginResult(model.message);	
				break;
		}

	}
	private void RegResult(string message)
	{
		BoolDTO dto = Coding<BoolDTO>.decode(message);
		if(dto.value)
		{
			WindowConstans.windowList.Add(WindowConstans.USR_REG_OK);
		}
		else
		{
			WindowConstans.windowList.Add(WindowConstans.USR_REG_FAIL);
		}
	}
	private void loginResult(string message)
	{
		Debug.Log(message);
	}
}
