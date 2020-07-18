using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEquipable {
	void EquipGun(Gun gun);
}

public class GunProps : GameProps
{
	private IEquipable equipable;
	private string propId;

	public GunProps(string id, IEquipable equipable, string propId) : base(id) {
		Name = propId;
		this.equipable = equipable;
		this.propId = propId;
	}
	public override void Pick()
	{
		Gun gun;
		switch(propId) {
			case "de":
			gun = PropCreator.CreateGunDe(10);
			break;
			case "m249":
			gun = PropCreator.CreateGunM249(10);
			break;
			default:
			gun = PropCreator.CreateGunDe(10);
			break;
		}
		Debug.Log("Pick");
		Debug.Log(gun);
		equipable.EquipGun(gun);

	}
	public override void Load()
	{
		Icon = Resources.Load<Texture>("icons/" + this.propId);
		Debug.Log(Icon);
	}
}
