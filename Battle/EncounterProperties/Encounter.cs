using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    namespace EncounterProperties
    {
        public class Encounter : MonoBehaviour
        {
            public List<BattleEntities.BattleEntity> enemies = new List<BattleEntities.BattleEntity>();

            //unity methods
            void OnTriggerEnter2D(Collider2D other)
            {
                if(other.tag == "Player")
                {
                    //TODO: Find enemies chasing player
                    Managers.BattleManager.StartBattle(this);
                }
            }
        }
    }
}
