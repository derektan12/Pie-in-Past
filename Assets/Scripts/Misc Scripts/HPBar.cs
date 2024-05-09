using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        if (player.health != player.maxHP)
        {
            transform.localScale = new Vector3((float)player.health / player.maxHP, 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change(Player player)
    {
        transform.localScale = new Vector3((float)player.health / player.maxHP, 1, 1);
    }
}
