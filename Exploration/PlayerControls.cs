using UnityEngine.InputSystem;
using UnityEngine;

namespace Exploration
{
    public class PlayerControls : MonoBehaviour
    {
        //public fields
        public MenuMessage.Talkables.BaseTalkable currentTalkable = null;

        //private fields
        Movement.EntityMovement entityMovement;

        //unity methods
        void Start()
        {
            entityMovement = GetComponent<Movement.EntityMovement>();
        }

        //control methods
        void OnConfirm()
        {
            switch(GameManager.gameMode)
            {
                case GameMode.exploration :
                    if(currentTalkable != null)
                    {
                        entityMovement.StopMoving();
                        currentTalkable.Talk();
                    }
                break;
                case GameMode.message :
                    if(currentTalkable != null)
                    {
                        currentTalkable.Talk();
                    }
                break;
            }
        }

        void OnMove(InputValue value)
        {
            if(GameManager.gameMode == GameMode.exploration)
            {
                entityMovement.DoMoving(value.Get<Vector2>(), true);
            }
        }

        void OnRun()
        {
            if(GameManager.gameMode == GameMode.exploration)
            {
                entityMovement.ToggleRunning();
            }
        }
    }
}
