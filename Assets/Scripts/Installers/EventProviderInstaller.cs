using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EventProviderInstaller : MonoInstaller
{
    [SerializeField] private EventProvider eventProvider ;

    public override void InstallBindings()
    {
        Container.Bind<EventProvider>().FromInstance(eventProvider);
    }
}