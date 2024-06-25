using System.Collections;
using System.Collections.Generic;
using Level;
using UnityEngine;
using Zenject;

public class LevelControllerInstaller : MonoInstaller
{
    [SerializeField] private LevelController levelController;
    public override void InstallBindings()
    {
        Container.Bind<LevelController>().FromInstance(levelController);
    }
}
