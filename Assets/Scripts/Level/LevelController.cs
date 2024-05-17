using System;
using Player;
using UnityEngine;
using Zenject;

namespace Level
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private LevelMaker levelMaker;
        [SerializeField] private PlayerPatternEndTracker playerPatternEndTracker;
        [SerializeField] private GameObject player;
        
        [Inject] private PlayerTemperature _playerTemperature;
        
        private void Start()
        {
            levelMaker.OneLevelIsDone += TeleportPlayerOnPatternStart;
            playerPatternEndTracker.OnEndPattern += levelMaker.ShowNextPattern;
            levelMaker.LevelPoolIsEnded += ScenesManager.LoadShop;
            levelMaker.ShowNextPattern();
        }

        public void TeleportPlayerOnPatternStart(Transform point)
        {
            if (_playerTemperature is not null)
                _playerTemperature.currentTemperature = 0f;
            player.transform.position = point.position;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero; //Make stop player
        }
    }
}