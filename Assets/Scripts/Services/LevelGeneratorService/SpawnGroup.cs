using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Services.LevelGeneratorService
{
    public class SpawnGroup : MonoBehaviour
    {
        [SerializeField] private List<GameObject> objects;
        [SerializeField] private int countToSpawn;

        public void GenerateSpawnGroup()
        {
            var indexes = new List<int>();
            for (int i = 0; i < objects.Count; i++)
            {
                indexes.Add(i);
            }

            var random = new Random();
            for (int i = 0; i < countToSpawn; i++)
            {
                var number = random.Next(objects.Count - i);
                indexes.RemoveAt(number);
            }

            foreach (var index in indexes)
            {
                Destroy(objects[index]);
            }
        }
    }
}