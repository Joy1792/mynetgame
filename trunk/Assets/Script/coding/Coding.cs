using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Coding<T>
{
	public static string encode(T model)
	{
		return JsonMapper.ToJson(model);
	}
	public static T decode(string message)
	{
		return JsonMapper.ToObject<T>(message);
	}
}
