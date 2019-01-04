using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
    private Animator _animator;

    // The target marker.
    public Transform target;

    //stats scripti cek
    public Stats stats;


    //death animasyonunu bir kere oynatmasi icin
    bool playedDeathAnim;

    //ok atisini debug icin
    bool isLaunched;


    // Use this for initialization
    void Start () 
    {
        _animator = gameObject.GetComponent<Animator>();
        stats = gameObject.GetComponent<Stats>();

    }
	
	// Update is called once per frame
	void Update () 
    {
        if(stats.isAlive)
        {
            if(!stats.isAttacking)
            {
                //hizi default hale getir
                stats.currentSpeed = stats.defaultSpeed;
                //saldiracak bir seyi yoksa karsi kaleye dogru gitsin
                TargetEnemyCastle();
                RunToTarget();
            }
            else
            {
                if (target == null || !target.gameObject.GetComponent<Stats>().isAlive)
                {
                    //Debug.Log("TARGET NULL");
                    stats.isAttacking = false;

                }
            }
        }

        if (!stats.isAlive && !playedDeathAnim)
        {
            //Debug.Log(gameObject + ": Vefad");
            _animator.Play("death");
            playedDeathAnim = true;
        }

        //Debug.Log(target);
        

    }

    void Attack(GameObject attackTarget)
    {
        stats.isAttacking = true;
        target = attackTarget.transform;

        _animator.Play("attack1");

        transform.LookAt(attackTarget.transform);

        if ((stats.lastAttackTime >= (stats.attackWaitTime-0.6f)) && !isLaunched)
        {
            if (gameObject.name == "archer(Clone)")
            {
                GameObject arrow = (GameObject)Instantiate(Resources.Load("Prefabs/Units/Arrow_Regular"), new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation) as GameObject;
                arrow.GetComponent<Arrow>().LaunchArrow(attackTarget);
                isLaunched = true;
            }

        }
            
        if (stats.lastAttackTime >= stats.attackWaitTime)
        {
            //ice vs fire
            if(stats.iceUpgrade >=1 && attackTarget.GetComponent<Stats>().fireUpgrade >= 1)
            {
                attackTarget.SendMessage("receiveDamage", (stats.damage + stats.iceUpgrade));
            }
            //fire vs nature
            else if (stats.fireUpgrade >= 1 && attackTarget.GetComponent<Stats>().natureUpgrade >= 1)
            {
                attackTarget.SendMessage("receiveDamage", (stats.damage + stats.fireUpgrade));
            }
            //nature vs ice
            else if (stats.natureUpgrade >= 1 && attackTarget.GetComponent<Stats>().iceUpgrade >= 1)
            {
                attackTarget.SendMessage("receiveDamage", (stats.damage + stats.natureUpgrade));
            }

            //ice vs default
            else if (stats.iceUpgrade >= 1 && (attackTarget.GetComponent<Stats>().iceUpgrade == 0 && attackTarget.GetComponent<Stats>().fireUpgrade == 0 && attackTarget.GetComponent<Stats>().natureUpgrade == 0))
            {
                attackTarget.SendMessage("receiveDamage", (stats.damage + stats.iceUpgrade));
            }
            //fire vs default
            else if (stats.fireUpgrade >= 1 && (attackTarget.GetComponent<Stats>().iceUpgrade == 0 && attackTarget.GetComponent<Stats>().fireUpgrade == 0 && attackTarget.GetComponent<Stats>().natureUpgrade == 0))
            {
                attackTarget.SendMessage("receiveDamage", (stats.damage + stats.fireUpgrade));
            }
            //nature vs default
            else if (stats.natureUpgrade >= 1 && (attackTarget.GetComponent<Stats>().iceUpgrade == 0 && attackTarget.GetComponent<Stats>().fireUpgrade == 0 && attackTarget.GetComponent<Stats>().natureUpgrade == 0))
            {
                attackTarget.SendMessage("receiveDamage", (stats.damage + stats.natureUpgrade));
            }

            //default vs hepsi
            else
            {
                attackTarget.SendMessage("receiveDamage", stats.damage);
            }  

            isLaunched = false;
            stats.lastAttackTime = 0;

        }

        


    }

    void TargetEnemyCastle()
    {
        if (gameObject.tag == "Bot")
        {
            target = GameObject.Find("castle_player").transform;
        }
        if (gameObject.tag == "Player")
        {
            target = GameObject.Find("castle_bot").transform;
        }
    }

    void RunToTarget()
    {
        // The step size is equal to speed times frame time.
        float step = stats.currentSpeed * Time.deltaTime;

        // Move our position a step closer to the target.
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        transform.LookAt(target);

        _animator.Play("run");
    }

}
