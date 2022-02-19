using UnityEngine;

namespace Exploration
{
    namespace Following {
        public class StaticFollow : MonoBehaviour
        {
            //public fields
            public Transform target;

            //private, serialized fields
            [SerializeField]
            Vector3 offset;

            // Update is called once per frame
            void Update()
            {
                transform.position = target.position + offset;
            }
        }
    }
}