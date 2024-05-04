using UnityEngine.Events;

namespace TowerDefense.Script
{
    public abstract class Hp : UnityEvent<int>
    {
    }

    public abstract class Money : UnityEvent<int>
    {
    }

    public abstract class PremiumMoney : UnityEvent<int>
    {
    }

    public abstract class Progress : UnityEvent<int, int>
    {
    }
}