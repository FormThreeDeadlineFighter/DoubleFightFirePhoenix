using UnityEngine;

public class EnemyBullet_1 : IBullet
{
    void Start()
    {
        speed = 10;
    }

    void Update()
    {
        //子彈向後飛行
        transform.Translate(Vector3.back*speed*Time.deltaTime);
    }
}
