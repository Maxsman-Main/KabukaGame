using System.Collections.Generic;
using UnityEngine;

namespace Services.LevelGeneratorService
{
    public interface IGenerator
    {
        public List<GameObject> GenerateLevelWithoutParameters();
    }
}