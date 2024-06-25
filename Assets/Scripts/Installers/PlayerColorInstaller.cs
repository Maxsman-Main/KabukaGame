using UnityEngine;
using Zenject;

public class PlayerColorInstaller : MonoInstaller
{
    [SerializeField] private PlayerColor playerColor;
    public override void InstallBindings()
    {
        Container.Bind<PlayerColor>().FromInstance(playerColor);
    }
}