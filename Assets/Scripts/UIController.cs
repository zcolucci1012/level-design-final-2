using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject bossHealthBar;
    public GameObject objective;
    private string obj = "OBJECTIVE: Destroy all Liches.";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowBossHealth(bool show)
    {
        this.bossHealthBar.SetActive(show);
    }
    
    public void UpdateObjective(string obj)
    {
        this.obj = obj;
        this.objective.GetComponent<Text>().text = obj;
    }
}
