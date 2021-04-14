using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Enemy
{
    public Slider healthBar;

    protected override void Move()
    {

    }

    protected override void Update()
    {
        base.Update();
        healthBar.value = this.currentHealth;
    }

    protected override void EnemyDies()
    {
        GameObject.Find("Canvas").GetComponent<UIController>().ShowBossHealth(false);
        GameObject.Find("Canvas").GetComponent<UIController>().UpdateObjective("OBJECTIVE: Enter the portal.");
        GameObject.Find("Hole").GetComponent<EnterPortal>().SetOpen(true);
        base.EnemyDies();
    }
}
