using Level;
using UnityEngine;

namespace Services.LevelGeneratorService
{
    public class LevelPattern : MonoBehaviour
    {
        [SerializeField] private StartPoint playerPosition;
        [SerializeField] private EndPoint patternEndPosition;

        public Transform PlayerPosition => playerPosition.transform;
        public Transform PatternEndPosition => patternEndPosition.transform;
    }
}