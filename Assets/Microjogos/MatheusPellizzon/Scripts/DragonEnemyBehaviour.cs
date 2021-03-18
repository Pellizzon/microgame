﻿using UnityEngine;

public class DragonEnemyBehaviour : MonoBehaviour
{
    private float Timer;
    private Camera cam;
    private float minH, maxH;
    public GameObject fireball;

    private float interval; // dificuldade 1: 1.0f; dificuldade 2: 0.5f; dificuldade 3: 0.25f; 
    void Start()
    {
        Timer = Time.time;
        //https://answers.unity.com/questions/230190/how-to-get-the-width-and-height-of-a-orthographic.html
        cam = Camera.main;
        float heightCamera = 2f * cam.orthographicSize;

        minH = cam.transform.position.y - heightCamera / 2;
        maxH = cam.transform.position.y + heightCamera / 2;
        Timer = Time.time + .5f;

        interval = 1.0f;
    }

    public AudioClip fireballSFX;
    void Update()
    {
        float boundY = fireball.GetComponent<CircleCollider2D>().radius;
        if (Timer < Time.time)
        {
            GameObject enemy = GameObject.FindWithTag("Enemy");
            Vector3 enemyPos = enemy.transform.position;
            enemyPos.y = Random.Range(minH + boundY, maxH - boundY);
            Quaternion rotation = enemy.transform.rotation;
            Vector3 spawnPos = enemyPos;
            Instantiate(fireball, spawnPos, rotation);
            AudioManager.PlaySFX(fireballSFX);
            Timer = Time.time + interval;
        }

    }
}