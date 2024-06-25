using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ManagerInstaller : MonoInstaller
{
    [SerializeField] private ResourceManager resourceManager;
    public override void InstallBindings()
    {
        Container.Bind<ResourceManager>().FromInstance(resourceManager);
        Container.Bind<SaveManager>().AsSingle();
        Container.Bind<ResourceData>().AsSingle();
    }
}
