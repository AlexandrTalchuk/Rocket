using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed;
    Vector2 _direction;
    bool isReady;


    void Awake()
    {
        speed = 5f;
        isReady = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetDirection(Vector2 Direction)//установка направления пули
    {
        _direction = Direction.normalized;//для получения вектора
        isReady = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            Vector2 position = transform.position;//текущая позиция пули 

            position += _direction * speed * Time.deltaTime;

            transform.position = position;//обновляем позицию

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));//левый нижний угол экрана
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));//правый верхний угол экрана

            //если выходит за пределы экрана - удаляем
            if((transform.position.x<min.x)||(transform.position.x>max.x)|| (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }                 
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //определяет столкновение либо с врагом, либо с пулей врага
        if (col.tag == "PlayerShipTag")
        {
            Destroy(gameObject);
        }
    }
}
