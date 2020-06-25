using System.Collections;
using System.Collections.Generic;
using SWNetwork;
using UnityEngine;

public class testScript : MonoBehaviour
{
    SyncPropertyAgent syncPropertyAgent;
    NetworkID networkID;
    // Start is called before the first frame update
    void Start()
    {
        syncPropertyAgent = GetComponent<SyncPropertyAgent>();
        networkID = GetComponent<NetworkID>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            int modelIndex = syncPropertyAgent.GetPropertyWithName("test").GetIntValue();
            syncPropertyAgent.Modify("test",modelIndex+1);
            Debug.Log(modelIndex);
         
        }
    }
}
