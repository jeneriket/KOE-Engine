using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MenuMessage
{
    [System.Serializable]
    public class MessageBlock {
        public List<TextMessage> messages = new List<TextMessage>();
        
        [HideInInspector]
        public int messagesIndex = 0;

        public bool CompareIndexToMessagesCount()
        {
            return messagesIndex >= messages.Count;
        }

        public TextMessage GetCurrentTextMessage()
        {
            return messages[messagesIndex];
        }
    }

    namespace Talkables
    {
        [RequireComponent(typeof(Rigidbody2D))]
        public class BaseTalkable : MonoBehaviour
        {
            //protected, serialized fields
            [SerializeField]
            protected List<MessageBlock> messageBlocks = new List<MessageBlock>();
            
            //protected fields
            protected int currentMessageBlock = 0;

            //public methods
            public void Talk()
            {
                if(!Managers.TextManager.textDone)
                {
                    if(!Managers.TextManager.displayingTextInCoroutine)
                    {
                        Managers.TextManager.ShowText(messageBlocks[currentMessageBlock].GetCurrentTextMessage());
                    }
                    else
                    {
                        Managers.TextManager.FillText(messageBlocks[currentMessageBlock].GetCurrentTextMessage());
                    }
                }
                else
                {
                    messageBlocks[currentMessageBlock].messagesIndex++;
                    
                    if(messageBlocks[currentMessageBlock].CompareIndexToMessagesCount())
                    {
                        Managers.TextManager.StopText();
                        messageBlocks[currentMessageBlock].messagesIndex = 0;
                    }
                    else {
                        Managers.TextManager.ShowText(messageBlocks[currentMessageBlock].GetCurrentTextMessage());
                    }
                }                
                /*else
                {
                    TextMessage currentMessage = messageBlocks[currentMessageBlock].GetCurrentTextMessage();

                    if(!Managers.TextManager.displayingTextInCoroutine)
                        messageBlocks[currentMessageBlock].messagesIndex++;

                    bool advanceText = !Managers.TextManager.displayingTextInCoroutine;
                    //Debug.Log("1 " + advanceText);
                    Managers.TextManager.ShowText(currentMessage);
                    //Debug.Log("2 " + advanceText);
                }*/
            }

            //unity methods
            void OnTriggerEnter2D(Collider2D other)
            {
                if(other.tag == "Player")
                {
                    if(GameManager.playerControls.currentTalkable == null)
                    {
                        GameManager.playerControls.currentTalkable = this;
                    }
                }
            }

            void OnTriggerExit2D(Collider2D other)
            {
                if(other.tag == "Player")
                {
                    if(GameManager.playerControls.currentTalkable == this)
                    {
                        GameManager.playerControls.currentTalkable = null;
                    }
                }
            }
        }
    }
    
}
