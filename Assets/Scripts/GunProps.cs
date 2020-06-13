using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunProps : GameProps
{
	public GunProps(string id) : base(id){
		Name = "M79";
	}
	public override void Pick()
	{
		Gun gun = PropCreator.CreateGun(10);
	}
	public override void Load()
	{
		Icon = Resources.Load<Texture>("icons/prop_gun_m79");
		Debug.Log(Icon);
	}
}
