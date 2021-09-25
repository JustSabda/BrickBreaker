using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public int force;
    int life;
    bool pause;
    int score;
    Text scoreUI;
    Text lifeUI;
    GameObject panelWin;
    GameObject panelLose;
    public int win;
    GameObject StartUI;
    
    public Transform nyawa;
    public Transform brick1;

    public PlayerMove player;

    
    // Start is called before the first frame update
    void Start()
    {
        panelWin = GameObject.Find("PanelSelesai");
        panelLose = GameObject.Find("PanelKalah");
        panelWin.SetActive(false);
        panelLose.SetActive(false);
        StartUI = GameObject.Find("Start");
        StartUI.SetActive(true);
        pause = true;
        rb = GetComponent<Rigidbody2D>();
        life = 3;
        score = 0;
        scoreUI = GameObject.Find("Score").GetComponent<Text>();
        lifeUI = GameObject.Find("Life").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")&& pause)
        {
            rb.AddForce(Vector2.down * force);
            pause = false;
            StartUI.SetActive(false);
        }
        if (Input.GetKeyDown("r"))
        {
            StartUI.SetActive(true);
            ResetBall();
            life -= 1;
            Text();
            player.awal();
            if (life == 0)
            {
                Destroy(gameObject);
                panelLose.SetActive(true);
                return;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "DeadLine")
        {
            StartUI.SetActive(true);
            ResetBall();
            life -= 1;
            Text();
            player.awal();
            if (life == 0)
            {
                Destroy(gameObject);
                panelLose.SetActive(true);
                StartUI.SetActive(false);
                return;
            }
        }
        if(collision.gameObject.name == "Player")
        {
            float tepi = (transform.position.x - collision.transform.position.x) * 5f;
            Vector2 arah = new Vector2(tepi, rb.velocity.y).normalized;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(arah * force * 2);
        }
        if (collision.transform.CompareTag("brick"))
        {
            score += 2;
            Text();
            int Luck = Random.Range(1, 101);
            if (Luck > 80)
            {
                Instantiate(nyawa, collision.transform.position, collision.transform.rotation);
            }
            Destroy(collision.gameObject);
        }
        if (collision.transform.CompareTag("brick2"))
        {
            score += 2;
            Text();
            Instantiate(brick1, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
        }
        if (score == win)
        {
            rb.velocity = new Vector2(0, 0);
            panelWin.SetActive(true);
            player.awal();
        }
    }
    public void ResetBall()
    {
        transform.localPosition = new Vector2(0, -2.5f);
        rb.velocity = new Vector2(0, 0);
        pause = true;
    }
    public void PlusLife()
    {
        if(life != 5)
        {
            life += 1;
            Text();
        }
    }
    void Text()
    {
        scoreUI.text = "Score : " + score +"";
        lifeUI.text = "Life : " + life + "";
    }

}
