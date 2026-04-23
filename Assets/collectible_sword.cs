using UnityEngine;

public class collectible_sword : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            player_script p = col.GetComponent<player_script>();
            p.coinsCollected++;
            Debug.Log(p.coinsCollected);
            Destroy(this.gameObject);
        }
    }
}
