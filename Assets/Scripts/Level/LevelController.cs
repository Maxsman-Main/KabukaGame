using System;
using Player;
using UnityEngine;

namespace Level
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private LevelMaker levelMaker;
        [SerializeField] private PlayerPatternEndTracker playerPatternEndTracker;
        [SerializeField] private GameObject player;
        
        private void Start()
        {
            levelMaker.OneLevelIsDone += TeleportPlayerOnPatternStart;
            playerPatternEndTracker.OnEndPattern += levelMaker.ShowNextPattern;
            levelMaker.ShowNextPattern();
        }

        private void TeleportPlayerOnPatternStart(Transform point)
        {
            player.transform.position = point.position;
        }
    }
}