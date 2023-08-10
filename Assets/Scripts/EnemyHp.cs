﻿using UnityEngine;

// FEEDBACK: у тебя у игрока и у врага в HP делается примерно одно и то же. Лучше не повторять код, а
// сделать один скрипт для HP, который будет работать и для одного, и для другого. Я тебе скину скрипт,
// который я какое-то время назад для ХП делал. Можешь поспрашивать по нему, если что-то не понятно
// и переписать его под свои нужды
public class EnemyHp : MonoBehaviour
{
    [SerializeField] private float hp;
    private Renderer rendr; // FEEDBACK: лучше SpriteRenderer использовать. Мы ж со спрайтами будет работать

    private void Awake()
    {
        rendr = GetComponent<Renderer>();
    }

    private void Update()
    {
        rendr.material.color = Color.Lerp(Color.red, Color.white, 0.2f * hp);

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeHit(float damage)
    {
        hp -= damage;
    }
}
