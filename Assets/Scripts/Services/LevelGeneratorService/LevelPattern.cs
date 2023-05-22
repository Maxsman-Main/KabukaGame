using System.Collections.Generic;
using Level;
using UnityEngine;

namespace Services.LevelGeneratorService
{
    public class LevelPattern : MonoBehaviour
    {
        [SerializeField] private StartPoint playerPosition;
        [SerializeField] private EndPoint patternEndPosition;
        [SerializeField] private List<SpawnGroup> spawnGroups;
        [SerializeField] private int levelComplexity;

        public Transform PlayerPosition => playerPosition.transform;
        public Transform PatternEndPosition => patternEndPosition.transform;

        public int LevelComplexity => levelComplexity;
        
        public void MakePatternGeneration()
        {
            foreach (var spawnGroup in spawnGroups)
            {
                spawnGroup.GenerateSpawnGroup();
            }
        }
    }
}