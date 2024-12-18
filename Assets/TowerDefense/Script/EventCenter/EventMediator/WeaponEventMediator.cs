namespace TowerDefense.Script.EventCenter.EventMediator
{
    public static class WeaponEventMediator
    {
        public static event System.Action<string> OnGachaGetWeapon;

        public static void DoGachaGetWeapon(string weaponName)
        {
            OnGachaGetWeapon?.Invoke(weaponName);
        }
    }
}