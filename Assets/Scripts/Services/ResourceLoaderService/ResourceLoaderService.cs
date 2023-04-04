using UnityEngine;

namespace Services.ResourceLoaderService
{
    public class ResourceLoaderService : IResourceLoader
    {
        public GameObject LoadPrefab(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return prefab;
        }

        public GameObject[] LoadPrefabs(string path)
        {
            var prefab = Resources.LoadAll<GameObject>(path);
            return prefab;
        }
    }
}