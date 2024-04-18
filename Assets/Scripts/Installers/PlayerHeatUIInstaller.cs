using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerHeatUIInstaller : MonoInstaller
{
    [SerializeField] private PlayerTemperature playerTemperature ;
    
    public override void InstallBindings()
    {
        Container.Bind<PlayerTemperature>().FromInstance(playerTemperature);
    }
}
