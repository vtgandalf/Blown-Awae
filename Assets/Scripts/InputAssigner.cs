using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAssigner : MonoBehaviour
{
    [SerializeField] private Player playerPrefab;
    [SerializeField] private List<KeyboardInput> keyboardInputs;
    [SerializeField] private SpawnPointRuntimeSet spawnPoints;
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
        for (int i = indexController.Count - 1; i >= 0; i--)
        {
            int controllerNumber = indexController[i];
            string button = "Joystick" + controllerNumber + "Button0";
            if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), button)))
            {
                SpawnPlayer(CreateJoystickInput(controllerNumber));

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
                SpawnPlayer(keyboardInputs[i]);

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

    private void SpawnPlayer(VirtualInput vi)
    {
        Vector3 spawnPoint = spawnPoints.GetRandomUnusedSpawnPoint();
        Debug.Log(spawnPoint);
        Player player = Instantiate(playerPrefab, spawnPoint, Quaternion.identity);

        //player.playerColor = Random.ColorHSV(0f, 1f);
        player.SetColor(Random.ColorHSV(0f, 1f));
        player.SetVirtualInput(vi);
        player.transform.GetChild(2).GetComponent<Canvas>().worldCamera = Camera.main;
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
