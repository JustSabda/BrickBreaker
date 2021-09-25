using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public string key;
    public float batasKiri;
    public float batasKanan;
    public Ball ball;

    bool start;
    
    // Start is called before the first frame update
    void Start()
    {
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (start == true)
        {
            float player = Input.GetAxis(key) * speed * Time.deltaTime;
            float batas = transform.position.x + player;
            if (batas < batasKiri || batas > batasKanan)
            {
                player = 0;
            }
            transform.Translate(player, 0, 0);
        }
        if (Input.GetKeyDown("space"))
        {
            start = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("ExtraLife"))
        {
            Destroy(collision.gameObject);
            ball.PlusLife();
        }
    }
    public void awal()
    {
        transform.localPosition = new Vector2(0, -3.99f);
        start = false;
    }
}
