using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPortal : MonoBehaviour
{
    private bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(open);
    }

    public void SetOpen(bool open)
    {
        this.open = open;
    }

    public void Enter()
    {
        if (this.open)
        {
            GameObject.Find("Canvas").GetComponent<UIController>().UpdateObjective("Scene Over.");
            Time.timeScale = 0;
        }
    }
}
