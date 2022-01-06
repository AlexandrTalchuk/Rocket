using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] int _health = 1;
    GameObject scoreUITextGO;
    float speed;
    public GameObject ExplosionGO;
    private EnemySpawner _enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        _enemySpawner = GameObject.Find("EnemySpawnerGO").GetComponent<EnemySpawner>();
        speed = 2f;
        scoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTextTag");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;//текущая позиция врага

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);//новая позиция

        transform.position = position;//обновляем позицию

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));//правый верхний угол экрана

       
        //если враг вылетел за экран - разрушаем
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //определяет столкновение либо с игроком, либо с пулей игрока
        if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
        {
            _health--;
            if(_health <= 0)
            {
                PlayExplosion();
                scoreUITextGO.GetComponent<GameScore>().Score += 100;
                Destroy(gameObject);
                _enemySpawner.KillCounter++;
            }
        }
    }
    void PlayExplosion()//проигрываем анимацию разрушения
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);
        explosion.transform.position = transform.position;
    }
}
