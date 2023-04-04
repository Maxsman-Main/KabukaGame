using System;
using Services.LevelGeneratorService;
using UnityEngine;
using Zenject;

namespace LevelMaker
{
    public class LevelMaker : MonoBehaviour
    {
        [Inject] private IGenerator _generator;

        private void Start()
        {
            var levels = _generator.GenerateLevelWithoutParameters();
            Instantiate(levels[1]);
        }
    }
}