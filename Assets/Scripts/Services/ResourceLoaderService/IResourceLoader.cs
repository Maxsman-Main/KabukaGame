using UnityEngine;

namespace Services.ResourceLoaderService
{
    public interface IResourceLoader
    {
        public GameObject LoadPrefab(string path);
        public GameObject[] LoadPrefabs(string path);
    }
}