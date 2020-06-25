using System.Collections;
using System.Collections.Generic;
using SWNetwork;
using UnityEngine;
using UnityEngine.UI;

public class testScript : MonoBehaviour
{
    SyncPropertyAgent syncPropertyAgent;
    NetworkID networkID;
    private Color[] _colors;
    private int currentColor = 0;
    private RemoteEventAgent _remoteEventAgent;
    
    private SpriteRenderer image;
    // Start is called before the first frame update
    void Start()
    {
        image = FindObjectOfType<SpriteRenderer>();
        syncPropertyAgent = GetComponent<SyncPropertyAgent>();
        networkID = GetComponent<NetworkID>();
        _colors = new[] {Color.red,Color.green, Color.blue, Color.yellow};
        _remoteEventAgent = GetComponent<RemoteEventAgent>();

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
           _remoteEventAgent.Invoke("changecolor");
           Debug.Log("cg 1");
        }
    }

    public void ChangeColor()
    {
        if (currentColor == 3)
        {
            currentColor = 0;
        }
        Debug.Log("cg 2");
        image.color = _colors[currentColor++];
    }
}
