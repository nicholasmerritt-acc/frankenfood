using UnityEngine;

public class Fighter : MonoBehaviour
{
    public float velocity = .1f;
    public Animator animator;
    bool fighting = false;
    public float health = 100f;
    public float damage = 10f;
    public Fighter enemy;
    public bool isEnemyBase = false;
    public bool isAllyBase = false;
    public Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Running_b", true);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if fighting, stop in place and deal damage
        if (fighting)
        {
            if (enemy == null)
            {
                //enemy must have died.
                FightOff();
            } 
            else
            {
                //deal damage
                enemy.health -= damage;

                //take damage
                health -= enemy.damage;

                //check deads
                if (health < 0)
                {
                    Destroy(this);
                } 
                else if (enemy.health < 0)
                {
                    if (enemy.isEnemyBase)
                    {
                        GameManager.Instance.Victory();
                    }
                    else if (enemy.isAllyBase)
                    {
                        GameManager.Instance.Defeat();
                    } else
                    {
                        Destroy(enemy.gameObject);
                    }
                    FightOff();
                }
            }

        }
        else
        {
            //not fighting, so let's run
            //transform.Translate(Vector3.right * velocity, Space.World);
            rb.MovePosition(rb.position + (Vector3.right * velocity));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{name} hit a {collision.gameObject.name}");
        if (collision.gameObject.CompareTag("Fighter") || collision.gameObject.CompareTag("Base"))
        {
            Debug.Log($"TRUE {name} hit a {collision.gameObject.name}");
            FightOn();
            enemy = collision.gameObject.GetComponent<Fighter>();
        }
    }

    private void FightOn()
    {
        fighting = true;
        animator.SetBool("Attack_b", true);
    }

    private void FightOff()
    {
        fighting = false;
        animator.SetBool("Attack_b", false);
    }
}
