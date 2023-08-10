using UnityEngine;

public class FindNearest : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    private GameObject target;

    [SerializeField] public GameObject nearest; // FEEDBACK: чекни подчёркивание от VS. У тебя SerializeField и public. Используй что-то одно. (:

    private GameObject FindClosestEnemy()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject go in enemy) // FEEDBACK: лучше изменить go на enemy. Сейчас это понятно, но привычка не очень.
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < distance)
            {
                target = go;
                distance = curDistance;
            }
        }

        if (target != null)
        {
            return target; // FEEDBACK: можешь просто сделать return target; -> если target == null, то ты просто вернёшь null. c:
        }
        else
        {
            return null;
        }
    }

    // FEEDBACK: FixedUpdate() используется для физики. Если хочешь по таймеру искать ближайшего врага,
    // то лучше сделать таймер в обычном Update()
    private void FixedUpdate()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy"); // FEEDBACK: очень сильно может по производительности ударить такой подход
        // Лучше в EnemySpawner запоминать всех врагов или через EnemySpawner с каждым новым заспавненным врагом
        // в отдельный скрипт со всеми врагами или в Player даже закидывать этого врага
        // Типа ты можешь сделать Instantiate(enemy), потом передать этого нового врага в FindNeares.Instance.AddEnemy();
        // А в AddEnemy ты врага записываешь в List<enemy> enemies;
        // List'ы -- крутые штуки. Это динамичные массивы. Из них же при смерти врагов, можешь удалять оттуда врагов
        nearest = FindClosestEnemy();      
    }
}
