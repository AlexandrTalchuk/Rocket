using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;//текущая позиция пули

        position = new Vector2(position.x, position.y + speed * Time.deltaTime);//новая позиция

        transform.position = position;//обновляем посицию

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));//правый верхний угол экрана

        //если пуля вылетела за экран - разрушаем
        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }


    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //определяет столкновение либо с врагом, либо с пулей врага
        if (col.tag == "EnemyShipTag")
        {
            Destroy(gameObject);
        }
    }
}
