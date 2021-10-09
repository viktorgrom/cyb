using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Image bar;
    public Image energy;
    public float fill;

    public int HP = 100;

    private void Start()
    {
        fill = 1f;
    }

    private void Update()
    {
        fill -= Time.deltaTime * 0.1f;
        bar.fillAmount = fill;

        if (HP < 1)
        {
            Debug.Log("Die");
            gameObject.SetActive(false);
        }
    }

    public void OnAttack()
    {
        fill += 0.2f;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Like")
        {
            fill += 0.2f;
            HP = HP - 10;
            Debug.Log(HP);

        }
    }
}
