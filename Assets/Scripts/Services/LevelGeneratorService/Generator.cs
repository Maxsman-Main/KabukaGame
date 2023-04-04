using System.Collections.Generic;
using System.Linq;
using Services.ResourceLoaderService;
using UnityEngine;
using Zenject;

namespace Services.LevelGeneratorService
{
    public class Generator : IGenerator
    {
        private const string LevelsPath = "Levels/Level1";
        
        [Inject] private IResourceLoader _resourceLoader;
        
        public List<GameObject> GenerateLevelWithoutParameters()
        {
            GameObject[] levels = _resourceLoader.LoadPrefabs(LevelsPath);
            var levelsList = levels.ToList();
            return levelsList;
        }
    }
}