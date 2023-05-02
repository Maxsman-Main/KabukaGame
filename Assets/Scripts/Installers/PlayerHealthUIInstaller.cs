using System.ComponentModel;
using UnityEngine;
using Zenject;
public class PlayerHealthUIInstaller : MonoInstaller
{
    [SerializeField] private Health health;
    public override void InstallBindings()
    {
        Container.Bind<Health>().FromInstance(health);
    }
}
