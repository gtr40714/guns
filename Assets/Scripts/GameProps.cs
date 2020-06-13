using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameProps
{

	protected GameProps(string id)
	{
		Id = id;
	}
	public Texture Icon {get; protected set;}
	public string Name {get; protected set;}
	public string Id {get;  private set;}
	public abstract void Pick();
	public abstract void Load();

}
