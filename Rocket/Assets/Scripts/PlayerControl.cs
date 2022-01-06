using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public GameObject GameManagerGO;

    public GameObject PlayerBulletGO;//префаб пули игрока
    public GameObject bulletPosition01;
    public GameObject bulletPosition02;
    public GameObject ExplosionGO;

    public Text LivesUIText;
    

    const int MaxLives = 3;
    int lives;
    
    public float speed;

    public void Init()
    {
        lives = MaxLives;
        LivesUIText.text = lives.ToString();
        transform.position = new Vector2(0, 0);
        gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //префаб пули активируется при нажатии на кнобку пробела

        if (Input.GetKeyDown("space"))
        {
            //музыка
            gameObject.GetComponent<AudioSource>().Play();
            //первая пуля
            GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGO);
            bullet01.transform.position = bulletPosition01.transform.position;
            //вторая пуля
            GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGO);
            bullet02.transform.position = bulletPosition02.transform.position;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical"); 
        Vector2 direction = new Vector2(x, y).normalized;
        Move(direction);
    }
    void Move (Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));//лимиты экрана
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));

        max.x = max.x - 0.225f;//вычитаем ширину(половину)
        min.x = min.x + 0.225f;//добавляем

        max.y = max.y - 0.285f;//тоже самое с высотой
        min.y = min.y + 0.285f;

        Vector2 pos = transform.position;//текущая позиция
        pos += direction * speed * Time.deltaTime;//новая позиция

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);//проверяем не вышли ли мы за пределы экрана
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);
        transform.position = pos;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //определяет столкновение либо с врагом, либо с пулей врага
        if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
        {
            PlayExplosion();
            lives--;
            LivesUIText.text = lives.ToString();

            if(lives == 0)
            {
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.Gameover);
                gameObject.SetActive(false);
            }
           
        }
    }
    void PlayExplosion()//проигрываем анимацию разрушения
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);
        explosion.transform.position = transform.position;
    }
}
