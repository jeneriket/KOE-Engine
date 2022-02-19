using UnityEngine;

public enum GameMode {
    exploration,
    menu,
    message,
    battle
}

public class GameManager : MonoBehaviour
{
    //public, static fields
    public static Exploration.Managers.SceneManager sceneManager;
    public static Exploration.PlayerControls playerControls;
    public static GameObject player;
    public static GameMode gameMode = GameMode.exploration;

    //private, serialized fields
    [SerializeField] 
    Texture2D cursor;
    [SerializeField]
    Exploration.PlayerControls setPlayerControls;
    [SerializeField]
    GameObject setPlayer;

    //public, static methods
    public static void SetSceneManager(Exploration.Managers.SceneManager newSceneManager)
    {
        //sceneManager.UnsetSceneVariables();

        Exploration.Managers.SceneManager oldSceneManager = sceneManager;

        sceneManager = newSceneManager;
        sceneManager.SetSceneVariables(oldSceneManager);
    }

    //unity methods
    void Start()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);

        playerControls = setPlayerControls;
        player = setPlayer;
    }

    //display game mode in unity editor only
    #if UNITY_EDITOR
    [SerializeField]
    GameMode gameModeShow;
    void Update()
    {
        gameModeShow = gameMode;
    }
    #endif
}
