using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    namespace Managers
    {
        [RequireComponent(typeof(MoveToBattlePositionManager))]
        public class BattleManager : MonoBehaviour
        {
            //public fields
            public List<BattleEntities.BattleEntity> setParty = new List<BattleEntities.BattleEntity>();

            //public, static fields
            public static List<BattleEntities.BattleEntity> party = new List<BattleEntities.BattleEntity>();
            public static List<BattleEntities.BattleEntity> enemies = new List<BattleEntities.BattleEntity>();
            public static List<BattleEntities.BattleEntity> allBattleEntities = new List<BattleEntities.BattleEntity>();

            public static bool battleReady = false;


            //public, static methods
            public static void StartBattle(EncounterProperties.Encounter battleEncounter)
            {
                enemies.Clear();
                enemies.AddRange(battleEncounter.enemies);

                allBattleEntities.Clear();
                allBattleEntities.AddRange(party);
                allBattleEntities.AddRange(enemies);

                //find closest battle area
                EncounterProperties.BattleArea[] battleAreas = GameObject.FindObjectsOfType<EncounterProperties.BattleArea>();

                GameManager.gameMode = GameMode.battle;
                GameManager.player.SendMessage("StopMoving");

                //TODO: Find closest battle area
                //TODO: Set battleReady to false
                //TODO: Have everyone in battle move towards designated positions
                //TODO: Set battle ready to true if they are at position
            }

            //unity methods
            void Start()
            {
                party = setParty;
            }
        }
    }
}
