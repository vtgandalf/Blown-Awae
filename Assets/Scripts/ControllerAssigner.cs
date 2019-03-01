using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAssigner : MonoBehaviour
{
    public Bomb throwingBomb;
    public Bomb bigBomb;
    public Transform prefab;
    private List<int> indexController;
    private void controlerDetection()
    {
        indexController = new List<int>();
        int counter = 0;
        foreach (string x in Input.GetJoystickNames())
        {
            if(x == "") 
            {
                //Debug.Log("empty controller");
            }
            else indexController.Add(counter+1); // coz the array position is actual-1
            counter ++;
        }
        foreach (int x in indexController)
        {
            //Debug.Log("Connected:" + x);
        }
        //Debug.Log(counter);
    }

    public List<int> GetListWithContollerNumbers()
    {
        controlerDetection();
        return this.indexController;
    }

    public void ListenForButtonPress()
    {
        foreach (int x in indexController)
        {
            string button = "Joystick"+ x + "Button0";
            if(Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), button)))
            {
                indexController.Remove(x);
                Transform playerTransform;
                playerTransform = Instantiate(prefab, new Vector3(0, 3, 0), Quaternion.identity);
                PlayerController playerController = playerTransform.GetComponent<PlayerController>();
                Player player = playerTransform.GetComponent<Player>();
                player.bigBomb = bigBomb;
                player.throwingBomb = throwingBomb;
                player.playerColor = Random.ColorHSV(0f, 1f);
                playerController.controllerNumber = x;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GetListWithContollerNumbers();
    }

    // Update is called once per frame
    void Update()
    {
        ListenForButtonPress();
    }
}
