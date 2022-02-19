using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using UnityEngine;
using TMPro;

namespace MenuMessage
{
    [System.Serializable]
    public class TextMessage {

        [TextArea(3,3)]
        public string text = string.Empty;
        public float textFillSpeed = 2f;
        public bool topText = false;
        public GameObject faceSprite = null;
    }

    [System.Serializable]
    public class TextBoxSet
    {
        public GameObject textBoxObject;
        public TextMeshProUGUI text;
        public GameObject faceBoxObject;

        GameObject currentFace = null;

        public void SetTextBoxActive(bool boxActive, GameObject faceObject = null)
        {
            if(currentFace != null && faceObject != currentFace)
            {
                GameObject.Destroy(currentFace);
            }

            textBoxObject.SetActive(boxActive);

            bool showFace = faceObject != null;
            faceBoxObject.SetActive(showFace);
            if(showFace)
            {
                currentFace = GameObject.Instantiate(faceObject, faceBoxObject.transform);
            }
        }
    }

    namespace Managers
    {

        public class TextManager : MonoBehaviour
        {
            //public, static fields
            public static bool displayingTextInCoroutine = false;
            public static bool textDone = false;

            //private, serialized fields
            [SerializeField]
            TextBoxSet setBottomTextBox;
            [SerializeField]
            TextBoxSet setTopTextBox;

            //private, static fields
            static TextManager textManager;

            static TextBoxSet bottomTextBox;
            static TextBoxSet topTextBox;
            static TextBoxSet currentTextBox = null;

            static GameMode returnGameMode = GameMode.exploration;
            
            //public, static methods
            public static void ShowText(TextMessage showMessage)
            {
                if(GameManager.gameMode != GameMode.message)
                    returnGameMode = GameManager.gameMode;

                GameManager.gameMode = GameMode.message;

                currentTextBox = showMessage.topText ? topTextBox : bottomTextBox;



                currentTextBox.SetTextBoxActive(true, showMessage.faceSprite);

                textDone = false;

                textManager.StopAllCoroutines();
                textManager.StartCoroutine(textManager.DisplayTextMessageCoroutine(showMessage));
            }

            public static void FillText(TextMessage showMessage)
            {
                textManager.StopAllCoroutines();
                displayingTextInCoroutine = false;
                textDone = true;
                currentTextBox.text.text = showMessage.text;
            }

            public static void StopText()
            {
                if (displayingTextInCoroutine){
                    return;
                }

                textDone = false;
                
                GameManager.gameMode = returnGameMode;

                currentTextBox.SetTextBoxActive(false);
            }

            //private coroutine functions
            IEnumerator DisplayTextMessageCoroutine(TextMessage message)
            {
                displayingTextInCoroutine = true;
                currentTextBox.text.text = string.Empty;

                int stringIndex = 0;
                while(currentTextBox.text.text.Length < message.text.Length)
                {
                    currentTextBox.text.text += message.text[stringIndex];
                    stringIndex++;

                    yield return new WaitForSeconds(message.textFillSpeed * Time.fixedDeltaTime);
                }
                
                textDone = true;
                displayingTextInCoroutine = false;
                yield return null;
            }

            //unity methods
            void Start()
            {
                textManager = this;                
                bottomTextBox = setBottomTextBox;
                topTextBox = setTopTextBox;

                bottomTextBox.SetTextBoxActive(false);
                topTextBox.SetTextBoxActive(false);
            }
        }
    }
}
