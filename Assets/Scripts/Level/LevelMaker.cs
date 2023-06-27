using System;
using System.Collections.Generic;
using Services.LevelGeneratorService;
using UnityEngine;
using Zenject;

namespace Level
{
    public class LevelMaker : MonoBehaviour
    {
        [SerializeField] private int levelSize;
        
        [Inject] private IGenerator _generator;
        [Inject] private ResourceManager resourceManager;
        
        private List<GameObject> _levels;
        private int _currentLevel;
        private GameObject _currentLevelPrefab;

        public Action LevelPoolIsEnded;
        public Action<Transform> OneLevelIsDone;
        
        public void ShowNextPattern()
        {
            _currentLevel += 1;
            if (_currentLevel >= _levels.Count)
            {
                LevelPoolIsEnded?.Invoke();
                resourceManager.SaveResourceData();
                return;
            }

            Destroy(_currentLevelPrefab);
            _currentLevelPrefab = Instantiate(_levels[_currentLevel]);
            var levelPattern = _currentLevelPrefab.GetComponent<LevelPattern>();
            levelPattern.MakePatternGeneration();
            OneLevelIsDone?.Invoke(levelPattern.PlayerPosition);
        }
        
        private void Start()
        {
            _levels = _generator.GenerateRandomLevel(levelSize);
            _currentLevel = -1;
        }
    }
}