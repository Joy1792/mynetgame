using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MessageManager : MonoBehaviour
{
	private LoginHandler login;

	void Start()
	{
		login = GetComponent<LoginHandler>();
	}
	
	void Update()
	{
		List<SocketModel> list = NetWorkScript.getInstance().getList();
		for (int i = 0; i<8; i++)
		{
			if (list.Count > 0)
			{
				SocketModel model = list [0];
				OnMessge(model);
				list.RemoveAt(0);
			} else
			{
				break;
			}
		}
	}

	public void OnMessge(SocketModel model)
	{
		switch(model.type)
		{
		case Protocol.LOGIN:
				login.OnMessage(model);
				break;
			case Protocol.USER:
				break;
			case Protocol.MAP:
				break;
			default:
				//WindowConstans.windowList.Add(WindowConstans.SOCKETA_TYPE_FAIL);
				break;
		}
	}
}
