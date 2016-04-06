using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public float maxHealth = 100f;
    public float curHealth = 0f;
    public GameObject healthBar;
    public GameObject dropWhenDead;

    void Start () {
        curHealth = maxHealth;
	}
	
	void Update () {
	
	}

    void GetDamage(float damage)
    {
        curHealth = (curHealth - damage >= 0) ? curHealth - damage : 0;
        float calc_health = curHealth / maxHealth;
        SetValueHealthBar(calc_health);
        if (curHealth <= 0)
            DropObject();
    }

    void SetValueHealthBar(float value)
    {
        healthBar.transform.localScale = new Vector3(value, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GetDamage(30);
    }

    void DropObject()
    {
        Instantiate(dropWhenDead, transform.localPosition, Quaternion.identity);
        Destroy(gameObject);
    }
}
