using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private bool pieCollected;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        pieCollected = false;
        Player player = GameObject.Find("Player").GetComponent<Player>();
        player.transform.position = transform.position;
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        pieCollected = true;
        print("test");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player" && pieCollected)
        {
            SceneManager.LoadScene(index);
        }
    }
}
