using UnityEngine;

public class PropCreator {

	private static int serialId = 0;

	// public static Gun CreateGun(int atk)
	// {
	// 	float r = Random.value;
	// 	if(r < .5f) {
	// 		return CreateGunDe(atk);
	// 	} else {
	// 		return CreateGunM249(atk);
	// 	}
	// 	// Gun gun = new Gun();
	// 	// gun.AttackValue = atk;
	// 	// gun.AttackRange = 10;
	// 	// gun.ResPath = "Prefabs/Weapon/de";
	// 	// return gun;
	// }

	public static Gun CreateGunDe(int atk)
	{
		Gun gun = new Gun();
		gun.AttackValue = atk;
		gun.AttackRange = 10;
		gun.ResPath = "Prefabs/Weapon/de";
		return gun;
	}

	public static Gun CreateGunM249(int atk)
	{
		Gun gun = new Gun();
		gun.AttackValue = atk;
		gun.AttackRange = 10;
		gun.ResPath = "Prefabs/Weapon/M249";
		return gun;
	}

	public static GameProps CreateGunProp(IEquipable equipable)
	{
		GameProps props;
		float r = Random.value;
		if(r < .5f) {
			props = new GunProps(PropCreator.serialId.ToString(), equipable, "de");
		} else {
			props = new GunProps(PropCreator.serialId.ToString(), equipable, "m249");
		}
		PropCreator.serialId++;
		return props;
	}

}
