using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerContlorrer : MonoBehaviour
{
    public static float speed;
    [SerializeField] private float speed2 = 13f;

    public float jumpForce;
    private float muvInput;
    public bool faisingRight = true;    
    private bool isGraunded;
    public float ChekRadius;
    private int extraJumps;
    public int extrajumpValiu;
    public Transform graundChek;
    public LayerMask watIsGraund;
    private Rigidbody2D rb;
    public float normalSpeed;
    public float speedGo = 13;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private AudioSource CifriSound;
    [SerializeField] private AudioSource GameOver;
    [SerializeField] private AudioSource JumpSound;
    [SerializeField] private AudioSource CoinAudio;
    [SerializeField] private AudioSource Otnyatie_Jizni;
    [SerializeField] private GameObject Gamer;
    [SerializeField] private GameObject Buton_PlayGame;
  






    public Text coinsText2;
    public static int coins2 = 0;

    [SerializeField] Image Bar;
     static float HeldBar;

    [SerializeField] Text HpText;
   public static int hP;
    static int helBarTepm;


    [SerializeField]  Transform trans;

    //float x = 1f;
    //float y = 0.8f;



    public Text coinsText;
     static int coins = 0;





    private void Start()
    {
        // if (SceneManager.GetActiveScene().buildIndex == 2)
        //{

        //}
       
      
            hP = 1;
            coins2 = 0;
            coins = 0;
            HeldBar = 0f;

     


        HpText.text = hP.ToString();
        coinsText.text = coins.ToString();
        coinsText2.text = coins2.ToString();

        extraJumps = extrajumpValiu;
        rb = GetComponent<Rigidbody2D>();
       losePanel.SetActive(false);
        PlayerPrefs.DeleteAll();
    }



    private void FixedUpdate()
    {
       Move();
      
    }

    private void Update()
    {

        IsGround();

    }   


    public void IsGround()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (isGraunded == true)
            {
                extraJumps = extrajumpValiu;                   //   Метод проверяет на земле ли игрок
            }

            isGraunded = Physics2D.OverlapCircle(graundChek.position, ChekRadius, watIsGraund);

        }


    }

    public void OnJumpButtonDown()
    {

        //  RazmerSharika();
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (extraJumps > 0f)
            {
                rb.AddForce(Vector2.up * jumpForce);
                extraJumps--;
            }
            else if (extraJumps == 0f && isGraunded == true)      //    Метод отвечает за прижок
            {
                rb.AddForce(Vector2.up * jumpForce);
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
        CifriSound.Play();
        JumpSound.Play();
        Gamer.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
         Gamer.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
       
        Buton_PlayGame.SetActive(false);

    }



    //void RazmerSharika()
    // {
    //     x += 0.3f;
    //     trans.localScale = new Vector2(x * Time.timeScale, x * Time.timeScale);
    // }


    // public void RazmerSharikaUp()
    // {
    //     x -= 0.3f;
    //     trans.localScale = new Vector2(y * Time.timeScale, y * Time.timeScale);
    // }










    private void Move()                                               //  Метод для бега  Лево и Право
    {
        if(SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
        {
            rb.velocity = new Vector2(speed2, rb.velocity.y);
        }
        if ( SceneManager.GetActiveScene().buildIndex == 3)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
      
    }







     void OnTriggerEnter2D(Collider2D other)                     //Метод отвечает за смерть игрока 
    {

        if(other.tag == "Speed_0") {
            speed = 0f;
            LinesDrawer.boolController = true;
            Timer.timeLeft = 15;
        }

        if (other.tag == "chekPoint")
        {
            PlayerPrefs.SetFloat("xPos", Gamer.transform.position.x);
            PlayerPrefs.SetFloat("yPos", Gamer.transform.position.y);
            PlayerPrefs.SetInt("coins2", coins2);
            PlayerPrefs.SetInt("Coins", coins);
            PlayerPrefs.SetInt("hP", hP);

        }

     


        if (other.tag == "revers")
        {
            speed = -speed;
        }

        if(other.tag == "Coin2") {

                CoinAudio.Play();
                coins2++;
                coinsText2.text = coins2.ToString();
                Destroy(other.gameObject);
                Bar.fillAmount = HeldBar;

            
            if ((coins2 + 2) % 5f == 0)
            {
                HeldBar += 0.1f;
                helBarTepm = (int)(HeldBar * 10);

                if (helBarTepm == 10)
                {
                    HeldBar = 0f;
                }
            }

            if (coins2 % 50 == 0 && coins2 != 0)
            {
                hP++;
                HpText.text = hP.ToString();
            }
        }
        if (other.gameObject.tag == "Coin")
        {
            coins++;
            coinsText.text = coins.ToString();
            Destroy(other.gameObject);
        }






        if (other.tag == "Respawn" || other.tag == "Bomba" || other.tag == "Utilizator")
        {
       
                
                hP--;
                if (hP > 0)                                                             //
                {

                   Gamer.transform.position =  new Vector2(PlayerPrefs.GetFloat("xPos"), PlayerPrefs.GetFloat("yPos"));

                  
            }
            if (hP != 0)
                {
                    Otnyatie_Jizni.Play();
                }
                HpText.text = hP.ToString();
            Buton_PlayGame.SetActive(true);
            // Gamer.GetComponent<Rigidbody2D>().freezeRotation = false;
            Gamer.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            //  Gamer.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            //  Time.timeScale = 0f;


            Bar.fillAmount = HeldBar;
                if (hP <= 0)
                {
                    coins2 = 0;
                    coins = 0;
                    // SobranieFruktov.HeldBar = 0f;

                    GameOver.Play();
                    losePanel.SetActive(true);
                    Time.timeScale = 0f;
                    // SceneManager.LoadScene(0);
                }
            
         

        }



    }



    public void PlayGame()
    {
        speed = speedGo;
    }





}
