using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exploration
{
    namespace MapControls
    {
        [RequireComponent(typeof(Collider2D))]
        public class LayerSwitcher : MonoBehaviour
        {
            //private, serialized fields
            [SerializeField]
            Renderer switchTarget;
            [SerializeField]
            string onEnterSortingLayer;
            [SerializeField]
            string onExitSortingLayer;

            //unity methods
            void OnTriggerEnter2D(Collider2D other)
            {
                if(other.tag == "Player")
                {
                    switchTarget.sortingLayerName = onEnterSortingLayer;
                }
            }

            void OnTriggerExit2D(Collider2D other)
            {
                if(other.tag == "Player")
                {
                    switchTarget.sortingLayerName = onExitSortingLayer;
                }
            }
        }
    }
}
