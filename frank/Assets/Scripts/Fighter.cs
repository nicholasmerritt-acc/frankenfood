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
    public Rigidbody rigidBody;
    public GameManager gameManager;
    public bool isGrunt = false;
    public bool isBruiser = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Running_b", true);
        rigidBody = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); GetComponent<GameManager>();

        if (isGrunt)
        {
            damage += PlayerPrefs.GetInt("gruntDamage", 0);
        }
        else if (isBruiser)
        {
            health += PlayerPrefs.GetInt("bruiserHealth", 0);
        }
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
                        gameManager.Victory();
                    }
                    else if (enemy.isAllyBase)
                    {
                        gameManager.Defeat();
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
            rigidBody.MovePosition(rigidBody.position + (Vector3.right * velocity));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log($"{name} hit a {collision.gameObject.name}");
        if (collision.gameObject.CompareTag("Fighter") || collision.gameObject.CompareTag("Base"))
        {
            //Debug.Log($"{name} is fighting {collision.gameObject.name}");
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
