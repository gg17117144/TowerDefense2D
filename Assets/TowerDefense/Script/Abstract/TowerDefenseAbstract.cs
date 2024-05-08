using UnityEngine.Events;

namespace TowerDefense.Script.Abstract
{
    public abstract class Hp : UnityEvent<int>
    {
    }

    public abstract class Money : UnityEvent<int>
    {
    }

    public abstract class Loop : UnityEvent<int>
    {
    }

    public abstract class Progress : UnityEvent<int, float>
    {
    }

    public abstract class Experience : UnityEvent<float>
    {
    }
}