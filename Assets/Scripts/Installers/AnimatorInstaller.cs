using UnityEngine;
using Zenject;

public class AnimatorInstaller : MonoInstaller
{
    [SerializeField] private Animator animator;
    public override void InstallBindings()
    {
        Container.Bind<Animator>().FromInstance(animator);
    }
}