using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    namespace EncounterProperties
    {
        public class BattleArea : MonoBehaviour
        {
            //public, static methods
            public static List<BattleArea> battleAreas = new List<BattleArea>();
            
            //public fields
            [HideInInspector]
            public Vector2[] playerPositions = new Vector2[4];
            [HideInInspector]
            public Vector2[] enemyPositions = new Vector2[4];

            //private, serialized fields
            [SerializeField]
            GameObject playerPositionsParent;
            [SerializeField]
            GameObject enemyPositionsParent;

            //public, static methods
            public static BattleArea GetClosestBattleArea()
            {
                float distance = Mathf.Infinity;
                BattleArea returnBattleArea = battleAreas[0];

                foreach(BattleArea currentBattleArea in battleAreas)
                {
                    float currentDistance = Vector2.Distance(currentBattleArea.transform.position, GameManager.player.transform.position);
                    
                    if(currentDistance < distance)
                        returnBattleArea = currentBattleArea;
                }

                return returnBattleArea;
            }

            //unity methods
            void Start()
            {
                //TODO: NOTE: if problems occur with stray battle areas being in the list, they may not be unloading when the scene unloads
                battleAreas.Add(this);
                UnityEngine.SceneManagement.SceneManager.sceneUnloaded += UnloadBattleArea;

                Transform[] playerChildTransforms = playerPositionsParent.GetComponentsInChildren<Transform>();
                for(int i = 1; i < 5; i++)
                {
                    //starts at 1 so that it doesn't pick the parent transform
                    playerPositions[i-1] = playerChildTransforms[i].position;
                }

                Transform[] enemyChildTransforms = enemyPositionsParent.GetComponentsInChildren<Transform>();
                for(int i = 1; i < 5; i++)
                {
                    //starts at 1 so that it doesn't pick the parent transform
                    enemyPositions[i-1] = enemyChildTransforms[i].position;
                }
            }

            //private methods
            void UnloadBattleArea<Scene> (Scene scene)
            {
                battleAreas.Remove(this);
            }
        }
    }
}
