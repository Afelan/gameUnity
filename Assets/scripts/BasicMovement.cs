using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

  // attack function
private void drowSelected(){
  if (AttackPoint == null) return;
  Gizmos.DrawWireSphere(AttackPoint.position,attackRange);
}
    void TakeDamage(int damage)
    {
        curretHealth -= damage;
      //  healthBar.SetHealth(currentHealth);
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
      curretHealth = MaxHealth;
    //  healthBar.SetMaxHealth(MaxHealth);
    }
    // Update is called once per frame
    void Update()
    {
      if (useController){
        movement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVertical"), 0.0f);
      }else {
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
      }
      
      if (Input.GetButton("Fire") || Input.GetMouseButtonDown(0)) {
        Attack();
        
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
