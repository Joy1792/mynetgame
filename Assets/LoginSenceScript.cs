using UnityEngine;
using System.Collections;

public class LoginSenceScript : MonoBehaviour
{
	public GameObject regPanel;

	public void RegistClick()
	{
		if (GameInfo.GAME_STATE == GameState.RUN)
		{
			Debug.Log("Regist");
			GameInfo.GAME_STATE = GameState.USR_REG;
			regPanel.SetActive(true);
		}
	}

}
