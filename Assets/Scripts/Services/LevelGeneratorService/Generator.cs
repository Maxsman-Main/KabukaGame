using System;
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
            var generatedLevels = new List<GameObject>();
            var levelsList = levels.ToList();
            var difficultList = MakeDifficultList(levelsList);
            var random = new Random();
            
            for (int i = 0; i < size; i++)
            {
                var probabilities = GetProbabilities(difficultList, i + 1, 0.1);
                var next = random.NextDouble();
                for (var index = 0; index < probabilities.Count; index++)
                {
                    var probability = probabilities[index];
                    if (!(probability[0] <= next) || !(next < probability[1])) continue;
                    generatedLevels.Add(levelsList[index]);
                    levelsList.RemoveAt(index);
                    difficultList.RemoveAt(index);
                }
            }

            return generatedLevels;
        }

        private List<int> MakeDifficultList(List<GameObject> levelPatterns)
        {
            return levelPatterns
                .Select(pattern => 
                        pattern.GetComponent<LevelPattern>())
                    .Select(levelPattern => levelPattern.LevelComplexity)
                    .ToList();
        }

        private double GetWeight(int complexity, int weightNumber, double multiplier)
        {
            return complexity * Math.Exp(-complexity * multiplier * weightNumber);
        }

        private List<List<double>> GetProbabilities(List<int> difficulties, int generateStep, double multiplier)
        {
            var probabilities = new List<List<double>>();
            var weights = new List<double>();
            var total = 0d;
            foreach (var difficult in difficulties)
            {
                var weight = GetWeight(difficult, generateStep, multiplier);
                total += weight;
                weights.Add(weight);
            }

            var right = 0d;
            foreach (var weight in weights)
            {
                var left = right;
                right += weight;
                probabilities.Add(new List<double> 
                    {left / total, right / total}
                );
            }

            return probabilities;
        }
    }
}