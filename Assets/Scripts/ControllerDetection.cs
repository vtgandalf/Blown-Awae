using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDetection : MonoBehaviour
{
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
        return this.indexController();
    }
}
