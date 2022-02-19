using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exploration
{
    namespace Managers
    {
        public class SceneManager : MonoBehaviour
        {
            //public, static fields
            public static TilemapManager sceneTilemapManager;

            //public fields
            public AudioSource overworldTheme;

            //private, serialized fields
            [SerializeField]
            TilemapManager setSceneTilemapManager;
            [SerializeField]
            List<int> surroundingMapsToLoad = new List<int>();
            [SerializeField]
            int sceneNumber = 1;

            //private, static fields
            static List<int> loadedMaps = new List<int>();

            //unity methods
            void Start()
            {
                if(GameManager.sceneManager == null)
                {
                    GameManager.SetSceneManager(this);
                    loadedMaps.Add(sceneNumber);
                }
            }

            //public methods
            public void SetSceneVariables(SceneManager previousSceneManager = null)
            {
                sceneTilemapManager = setSceneTilemapManager;

                //crossfade scenes
                if(previousSceneManager != null)
                {
                    previousSceneManager.StopAllCoroutines();
                    StopAllCoroutines();
                    StartCoroutine(CrossfadeOverworldThemes(previousSceneManager.overworldTheme));
                }
                else
                {
                    overworldTheme.Play();
                }

                //async load maps
                foreach(int mapNum in surroundingMapsToLoad)
                {
                    if(!loadedMaps.Contains(mapNum))
                    {
                        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(mapNum, UnityEngine.SceneManagement.LoadSceneMode.Additive);
                        loadedMaps.Add(mapNum);
                    }
                }

                //TODO: async unload unneeded maps
            }

            //private, coroutine methods
            IEnumerator CrossfadeOverworldThemes(AudioSource previousOverworldTheme, float volumeSpeedChange = 0.03f)
            {
                volumeSpeedChange *= Time.deltaTime;

                if(overworldTheme.volume == 1)
                {
                    overworldTheme.volume = 0;
                }
                if(!overworldTheme.isPlaying)
                {
                    overworldTheme.Play();
                }

                while(overworldTheme.volume != 1 || previousOverworldTheme.volume != 0)
                {
                    previousOverworldTheme.volume -= volumeSpeedChange;
                    overworldTheme.volume += volumeSpeedChange;

                    if(previousOverworldTheme.volume < 0)
                    {
                        previousOverworldTheme.volume = 0;
                    }

                    if(overworldTheme.volume > 1)
                    {
                        overworldTheme.volume = 1;
                    }

                    yield return null;
                }

                previousOverworldTheme.Stop();
            }
        }

    }
}