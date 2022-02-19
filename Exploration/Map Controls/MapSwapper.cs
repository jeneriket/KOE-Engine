using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exploration
{
    namespace MapControls
    {
        public class MapSwapper : MonoBehaviour
        {
            //private, serialized fields
            [SerializeField]
            Exploration.Managers.SceneManager sceneManager;

            //unity methods
            void OnTriggerEnter2D(Collider2D other)
            {
                if(other.tag == "Player" && GameManager.sceneManager != sceneManager)
                {
                    GameManager.SetSceneManager(sceneManager);
                }
            }
        }
    }
}
