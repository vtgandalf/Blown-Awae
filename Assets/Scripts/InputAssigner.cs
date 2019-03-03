using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAssigner : MonoBehaviour
{
    public Player playerPrefab;
    public List<KeyboardInput> keyboardInputs;
    private List<int> indexController;

    public void SetupKeyboardListeners()
    {
        foreach (KeyboardInput ki in keyboardInputs)
        {
            ki.OnThrowingBombDown.AddListener(delegate { OnKeyboardConfirm(ki); });
        }
    }

    private void OnKeyboardConfirm(KeyboardInput ki)
    {
        ki.OnThrowingBombDown.RemoveAllListeners();
        SpawnPlayer(ki);
    }

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
    
    public void ListenForJoystickConfirm()
    {
        for (int i = 0; i < indexController.Count; i++)
        {
            int controllerNumber = indexController[i];
            string button = "Joystick" + controllerNumber + "Button0";
            if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), button)))
            {
                SpawnPlayer(CreateJoystickInput(controllerNumber));

                indexController.RemoveAt(i);
                i--;
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
        Player player = Instantiate(playerPrefab, new Vector3(0, 3, 0), Quaternion.identity);

        //player.playerColor = Random.ColorHSV(0f, 1f);
        player.SetColor(Random.ColorHSV(0f, 1f));
        player.SetVirtualInput(vi);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupKeyboardListeners();
        GetListWithContollerNumbers();
    }

    void FixedUpdate()
    {
        ListenForJoystickConfirm();
    }
}
