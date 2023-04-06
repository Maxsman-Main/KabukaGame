using System.Collections.Generic;
using System.Linq;
using Services.ResourceLoaderService;
using UnityEngine;
using Zenject;
using Random = System.Random;

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

        public List<GameObject> GenerateRandomLevel(int size)
        {
            GameObject[] levels = _resourceLoader.LoadPrefabs(LevelsPath);
            var levelsList = levels.ToList();
            List<GameObject> shuffledList = ShuffleList(levelsList);
            shuffledList = shuffledList.GetRange(0, size);
            return shuffledList;
        }

        private List<GameObject> ShuffleList(List<GameObject> values)
        {
            var rand = new Random();
            
            for (var i = values.Count - 1; i > 0; i--) {
                var k = rand.Next(i + 1);
                (values[k], values[i]) = (values[i], values[k]);
            }

            return values;
        }
    }
}