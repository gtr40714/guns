public class PropCreator {

	private static int serialId = 0;

	public static Gun CreateGun(int atk)
	{
		Gun gun = new Gun();
		gun.AttackValue = atk;
		gun.AttackRange = 10;
		return gun;
	}

	public static GameProps CreateGunProp()
	{
		GameProps props = new GunProps(PropCreator.serialId.ToString());
		PropCreator.serialId++;
		return props;
	}

}
