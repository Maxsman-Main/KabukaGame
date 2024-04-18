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
            levelMaker.LevelPoolIsEnded += ScenesManager.LoadShop;
            levelMaker.ShowNextPattern();
        }

        public void TeleportPlayerOnPatternStart(Transform point)
        {
            player.transform.position = point.position;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero; //Make stop player
        }
    }
}