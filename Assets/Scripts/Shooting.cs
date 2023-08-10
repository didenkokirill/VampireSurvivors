using UnityEngine;

public class Shooting : MonoBehaviour
{
    // FEEDBACK: Я бы советовал сначала показывать переменые, которые мы скорее всего будем изменять через Inspector,
    // а потом уже референсы к bullet и так далее
    // так удобнее, сразу будешь видеть, что ты можешь изменить, а что не нужно
    [SerializeField] private Transform[] firePoints;
    [SerializeField] private GameObject bullet;

    [SerializeField] private int weaponNum; // FEEDBACK: тут можно создать enum с человеческими названиями
    // вот вернёшься ты к проекту через месяц, а у нас уже 10 оружий. Тебе придётся вспоминать, что значит 1, а что 7. (:

    [SerializeField] private float attackDelay = 5;
    [SerializeField] private float attackRange = 10;
    [SerializeField] private float bulletForse = 30; // FEEDBACK: Это можно потенциально в prefab пули закинуть. Но не обязательно сейчас.
    [SerializeField] private float bulletDamage = 1; // FEEDBACK: Это тоже можно потенциально в prefab пули закинуть.
    
    [Header("Rocket Laucher")]
    [SerializeField] private float splashDamage = 1;
    [SerializeField] private float splashRange = 0;

    private float attackTimer;
   
    private void Update()
    {
        // FEEDBACK: очень дорого по производительности так делать каждый фрейм. Лучше кэшируй FindNearest в Start()
        GameObject nearestTarget = GetComponentInParent<FindNearest>().nearest;

        // FEEDBACK: есть правило чистого кода: если у тебя больше 3-х вложений if () { if () { if () {}}},
        // то лучше переписывать код как-то иначе
        
        #region вот как можно было бы переписать, чтобы избежать кучи вложенности

        if (attackTimer <= attackDelay)
        {
            return;
        }

        if (nearestTarget == null)
        {
            return;
        }

        if (Vector3.Distance(transform.position, nearestTarget.transform.position) > attackRange)
        {
            return;
        }

        // FEEDBACK: тут switch лучше использовать. Если ты в enum перепишешь, то switch тебе как раз понадобится
        if (weaponNum == 1)
        {
            MachineGunShoot();
        }
        if (weaponNum == 2)
        {
            ShotGunShoot();
        }
        if (weaponNum == 3)
        {
            RocketLauncherShoot();
        }

        attackTimer = 0;

        #endregion

        #region твой вариант
        attackTimer++;
        if (attackTimer > attackDelay)
        {
            if (nearestTarget != null)
            {
                if (Vector3.Distance(transform.position, nearestTarget.transform.position) <= attackRange)
                {
                    if (weaponNum == 1)
                    {
                        MachineGunShoot();
                    }
                    if (weaponNum == 2)
                    {
                        ShotGunShoot();
                    }
                    if(weaponNum == 3)
                    {
                        RocketLauncherShoot();
                    }

                    attackTimer = 0;
                }
            }           
        }

        #endregion
    }

    private void MachineGunShoot()
    {      
        GameObject clone = Instantiate(bullet, firePoints[0].transform.position, firePoints[0].transform.rotation);
        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
        clone.GetComponent<Bullet>().damage = bulletDamage; // FEEDBACK: лучше сразу в Bullet передавать bulletForse
                                                            // и там же внутри Bullet обрабатывать rb.AddForce()
                                                            // Shooting должен только спавнить префаб и передавать ему все
                                                            // нужные данные. Bullet уже пусть сам разбирается, что делать с
                                                            // этими данными
        rb.AddForce(firePoints[0].up * bulletForse, ForceMode2D.Impulse);
    }

    private void ShotGunShoot()
    {
        // FEEDBACK: помимо фидбека, что я писал выше про Bullet, у тебя тут куча повторяющегося кода.
        // лучше написать метод типа SpawnBullet() или Shoot(), где у тебя по возможности всё будет унифицированно

        for (var i = 0; i < firePoints.Length; i++)
        {
            GameObject clone = Instantiate(bullet, firePoints[i].transform.position, firePoints[i].transform.rotation);
            clone.GetComponent<Bullet>().damage = bulletDamage;
            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoints[i].up * bulletForse, ForceMode2D.Impulse);
        }
    }

    private void RocketLauncherShoot()
    {
        // FEEDBACK: такие же комменты, как и выше. (:
        GameObject clone = Instantiate(bullet, firePoints[0].transform.position, firePoints[0].transform.rotation);
        clone.GetComponent<Bullet>().damage = splashDamage;
        clone.GetComponent<Bullet>().splashRange = splashRange;
        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoints[0].up * bulletForse, ForceMode2D.Impulse);
    }
}
