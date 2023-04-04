using Scriptable.Move;
using Services.InputService;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PlayerMovementInstaller : MonoInstaller
    {
        [SerializeField] private Movement movement;
        
        public override void InstallBindings()
        {
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
            Container.Bind<Movement>().FromInstance(movement);
        }
    }
}