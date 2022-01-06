using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyBulletGO;
    public GameObject EnemyBullet1GO;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("FireEnemyBullet", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.Find("PlayerGO");//ищем игрока
        if (playerShip != null)
        {
            if (gameObject.transform.parent.gameObject.name == "EnemyMidBoss(Clone)")
            {
                GameObject bullet1 = (GameObject)Instantiate(EnemyBulletGO);//создаем экземпляр пули врага
                GameObject bullet2 = Instantiate(EnemyBulletGO) as GameObject;
                GameObject bullet3 = Instantiate(EnemyBulletGO) as GameObject;
                GameObject bullet4 = Instantiate(EnemyBulletGO) as GameObject;
                GameObject bullet5 = Instantiate(EnemyBulletGO) as GameObject;
                GameObject bullet6 = Instantiate(EnemyBulletGO) as GameObject;
                GameObject bullet7 = Instantiate(EnemyBulletGO) as GameObject;
                bullet1.transform.position = transform.position;//позиция
                bullet2.transform.position = transform.position;//позиция
                bullet3.transform.position = transform.position;//позиция
                bullet4.transform.position = transform.position;//позиция
                bullet5.transform.position = transform.position;//позиция
                bullet6.transform.position = transform.position;//позиция
                bullet7.transform.position = transform.position;//позиция
                Vector2 direction1 = playerShip.transform.position - bullet1.transform.position;//вычисляем положение пули относительно игрока
                Vector2 direction2 = playerShip.transform.position - bullet1.transform.position -bullet2.transform.position;//вычисляем положение пули относительно игрока
                Vector2 direction3 = playerShip.transform.position - bullet1.transform.position - bullet2.transform.position - bullet3.transform.position;//вычисляем положение пули относительно игрока
                Vector2 direction4 = playerShip.transform.position - bullet1.transform.position - bullet2.transform.position - bullet3.transform.position- bullet4.transform.position;
                Vector2 direction5 = playerShip.transform.position - bullet1.transform.position - bullet2.transform.position - bullet3.transform.position - bullet4.transform.position - bullet5.transform.position;
                Vector2 direction6 = playerShip.transform.position - bullet1.transform.position - bullet2.transform.position - bullet3.transform.position - bullet4.transform.position - bullet5.transform.position - bullet6.transform.position;
                Vector2 direction7 = playerShip.transform.position - bullet1.transform.position - bullet2.transform.position - bullet3.transform.position - bullet4.transform.position - bullet5.transform.position - bullet6.transform.position - bullet7.transform.position;
                bullet1.GetComponent<EnemyBullet>().SetDirection(direction1);//задаем направление
                bullet2.GetComponent<EnemyBullet>().SetDirection(direction2);//задаем направление
                bullet3.GetComponent<EnemyBullet>().SetDirection(direction3);//задаем направление
                bullet4.GetComponent<EnemyBullet>().SetDirection(direction4);//задаем направление
                bullet5.GetComponent<EnemyBullet>().SetDirection(direction5);//задаем направление
                bullet6.GetComponent<EnemyBullet>().SetDirection(direction6);//задаем направление
                bullet7.GetComponent<EnemyBullet>().SetDirection(direction7);//задаем направление

            }
            else
            {
                GameObject bullet1 = (GameObject)Instantiate(EnemyBulletGO);//создаем экземпляр пули врага
                bullet1.transform.position = transform.position;//позиция
                Vector2 direction = playerShip.transform.position - bullet1.transform.position;//вычисляем положение пули относительно игрока
                bullet1.GetComponent<EnemyBullet>().SetDirection(direction);//задаем направление
                Debug.Log($"{gameObject.transform.parent.gameObject.name}");
            }
        }
    }
}
