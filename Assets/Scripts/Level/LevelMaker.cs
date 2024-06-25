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
        [Inject] private EventProvider _eventProvider;
        
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
                if (int.Parse(PlayerPrefs.GetString("NextLevel")[^1].ToString()) == 5 && PlayerPrefs.GetInt("WinGame", 0) == 0)
                {
                    PlayerPrefs.SetInt("WinGame", 1);
                    _eventProvider.IsGameFinish.Invoke();
                }
                else
                {
                    LevelPoolIsEnded?.Invoke();    
                }
                resourceManager.SaveResourceData();
                if (int.Parse(PlayerPrefs.GetString("NextLevel")[^1].ToString()) == PlayerPrefs.GetInt("LevelAvailable", 1))
                    PlayerPrefs.SetInt("LevelAvailable", PlayerPrefs.GetInt("LevelAvailable", 1) + 1);
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