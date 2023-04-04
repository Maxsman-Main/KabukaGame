using Services.LevelGeneratorService;
using Services.ResourceLoaderService;
using Zenject;

namespace Installers
{
    public class GeneratorInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IResourceLoader>().To<ResourceLoaderService>().AsSingle();
            Container.Bind<IGenerator>().To<Generator>().AsSingle();
        }
    }
}