using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAssigner : MonoBehaviour
{
    [SerializeField] private Player playerPrefab;
    [SerializeField] private List<KeyboardInput> keyboardInputs;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private SpawnPointRuntimeSet spawnPoints;
    [SerializeField] private PlayerSpawner playerSpawner;
    private List<int> indexController;

    //public void SetupKeyboardListeners()
    //{
    //    foreach (KeyboardInput ki in keyboardInputs)
    //    {
    //        ki.OnThrowingBombDown.AddListener(delegate { OnKeyboardConfirm(ki); });
    //    }
    //}

    //private void OnKeyboardConfirm(KeyboardInput ki)
    //{
    //    ki.OnThrowingBombDown.RemoveAllListeners();
    //    SpawnPlayer(ki);
    //}

    private void ControlerDetection()
    {
        indexController = new List<int>();
        int counter = 0;
        foreach (string x in Input.GetJoystickNames())
        {
            // Check if controller is empty
            if(x != "") 
            {
                indexController.Add(counter + 1); // coz the array position is actual-1
            }
            counter ++;
        }
    }

    public List<int> GetListWithContollerNumbers()
    {
        ControlerDetection();
        return this.indexController;
    }
    
    private void ListenForJoystickConfirm()
    {
        if (indexController.Count == 0)
            return;

        for (int i = indexController.Count - 1; i >= 0; i--)
        {
            int controllerNumber = indexController[i];
            string button = "Joystick" + controllerNumber + "Button7";
            if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), button)))
            {
                SpawnPlayer(CreateJoystickInput(controllerNumber), controllerNumber);
                indexController.RemoveAt(i);
            }
            button = "Joystick" + controllerNumber + "Button9";
            if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), button)))
            {
                SpawnPlayer(CreateJoyconInput(controllerNumber, true), controllerNumber);
                indexController.RemoveAt(i);
            }
            button = "Joystick" + controllerNumber + "Button8";
            if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), button)))
            {
                SpawnPlayer(CreateJoyconInput(controllerNumber, false), controllerNumber);
                indexController.RemoveAt(i);
            }
        }
    }

    private void ListenForKeyboardConfirm()
    {
        if (keyboardInputs.Count == 0)
            return;

        for (int i = keyboardInputs.Count - 1; i >= 0; i--)
        {
            if (Input.GetKeyDown(keyboardInputs[i].throwingBomb))
            {
                SpawnPlayer(keyboardInputs[i], 20);
                keyboardInputs.RemoveAt(i);
            }
        }
    }
    
    private JoystickInput CreateJoystickInput(int controllerId)
    {
        JoystickInput ji = ScriptableObject.CreateInstance<JoystickInput>();

        ji.SetControllerNumber(controllerId);

        return ji;
    }

    private JoyconInput CreateJoyconInput(int controllerId, bool usesPlus)
    {
        JoyconInput ji = ScriptableObject.CreateInstance<JoyconInput>();

        ji.SetControllerNumber(controllerId, usesPlus);

        return ji;
    }

    private void SpawnPlayer(VirtualInput vi, int controllerId)
    {
        Vector3 spawnPoint = spawnPoints.GetRandomUnusedSpawnPoint();
        Player player = Instantiate(playerPrefab, spawnPoint, Quaternion.identity);

        //player.playerColor = Random.ColorHSV(0f, 1f);
        //player.SetColor(Random.ColorHSV(0f, 1f));
        player.ControllerID = controllerId;
        playerSpawner.SetUpPlayerColor(player, player.ControllerID);
        player.SetVirtualInput(vi);
        player.transform.GetChild(2).GetComponent<Canvas>().worldCamera = Camera.main;
        player.GetComponent<PlayerController>().scoreManager = scoreManager;
    }

    // Start is called before the first frame update
    void Start()
    {
        GetListWithContollerNumbers();
    }

    void FixedUpdate()
    {
        ListenForJoystickConfirm();
        ListenForKeyboardConfirm();
    }
}
