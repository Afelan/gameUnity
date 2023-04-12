using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BasicMovement : MonoBehaviour
{
    // Start is called before the first frame update
   public Animator animator;
   public bool useController;
   Vector3 movement;
   public Transform AttackPoint;
   public float attackRange = 0.5f;
   public int attackDamage = 40;
   public LayerMask enemyLayers;
   public int MaxHealth = 100;
   public int curretHealth;
   public HealthBar healthBar;
   public GameObject deathScreen;
   public float AttackRate = 2f;
   float nextAttackTime = 0f;
  // attack function
private void drowSelected(){
  if (AttackPoint == null) return;
  Gizmos.DrawWireSphere(AttackPoint.position,attackRange);
}

void Die()
    {
        Debug.Log("Hero knight dead");
       
       
       if (!deathScreen.activeSelf)
            {
                
                deathScreen.SetActive(true);
                Time.timeScale=0;
            }
       
    }
    void TakeDamage(int damage)
    {
        attackDamage += 20;
        curretHealth -= damage;
        animator.SetTrigger("TakeHit");
        healthBar.SetHealth(curretHealth);
        
        if (curretHealth <= 0)
        {
            animator.SetBool("Isdead", true);
            Invoke("Die", 1);
           //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Attack()
    {
      
      animator.SetTrigger("Attack");
      Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);

      foreach(Collider2D enemy in hitEnemies)
      {
        enemy.GetComponent<Enemy>().TakeDamage(attackDamage); 
      }
    }

    void Start()
    {
      Time.timeScale=1f;
      curretHealth = MaxHealth;
      healthBar.SetMaxHealth(MaxHealth);
    }
    // Update is called once per frame
    void Update()
    {
      if (useController){
        movement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVertical"), 0.0f);
      }else {
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
      }
      
      if(Time.time >= nextAttackTime)
      {
        if (Input.GetButton("Fire") || Input.GetMouseButtonDown(0)) {
          Attack();
          nextAttackTime = Time.time + 1f / AttackRate;
          
        }
      }

      if (Input.GetKeyDown(KeyCode.Space))
      {
        TakeDamage(20);
      }
      animator.SetFloat("Horizontal", movement.x);
      animator.SetFloat("Vertical", movement.y);
      animator.SetFloat("Magnitude", movement.magnitude);
      //Move()
      
      transform.position = transform.position + movement * Time.deltaTime;

       
 
    }
  


}
