using UnityEngine;
using Zenject;

public class JoystickInputInstaller : MonoInstaller
{
    [SerializeField] private JoystickInput joystick;
    public override void InstallBindings()
    {
        Container.Bind<JoystickInput>().FromInstance(joystick);
    }
}