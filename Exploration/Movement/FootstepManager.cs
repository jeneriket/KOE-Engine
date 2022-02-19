using System.Collections.Generic;
using UnityEngine;

namespace Exploration
{
    namespace Movement
    {
        public enum FootstepMode
        {
            Default = 0,
            waterSplash,
            metal
        }

        public class FootstepManager : MonoBehaviour
        {            
            //private, serialized fields
            [SerializeField]
            List<AudioClip> defaultFootsteps = new List<AudioClip>();
            [SerializeField]
            List<AudioClip> waterSplashFootsteps = new List<AudioClip>();
            [SerializeField]
            List<AudioClip> metalFootsteps = new List<AudioClip>();

            //private fields
            AudioSource footstepSource;
            EntityMovement entityMovement;
            FootstepMode footstepMode = FootstepMode.Default;


            //public methods
            public void PlayFootstep()
            {
                List<AudioClip> clipList = defaultFootsteps;

                if(clipList.Count == 1)
                {
                    Debug.LogError("Cannot have only one footstep sound. Found on Footstep Manager for " + name);
                    return;
                }

                switch(footstepMode)
                {
                    case FootstepMode.waterSplash:
                        clipList = waterSplashFootsteps;
                    break;
                    case FootstepMode.metal:
                        clipList = metalFootsteps;
                    break;
                }

                int rand = Random.Range(0, clipList.Count);

                //don't let it use the same clip
                while(footstepSource.clip == clipList[rand])
                    rand = Random.Range(0, clipList.Count);
                
                footstepSource.clip = clipList[rand];
                footstepSource.Play();
            }

            // unity methods
            void Start()
            {
                entityMovement = GetComponent<EntityMovement>();

                footstepSource = GetComponentInChildren<AudioSource>();
            }
            
            void FixedUpdate()
            {
                footstepMode = Managers.SceneManager.sceneTilemapManager.GetPositionFootstepMode(entityMovement.movementDirection);
            }
        }
    }
}
