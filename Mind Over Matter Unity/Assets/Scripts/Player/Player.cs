using UnityEngine;
using System.Collections;
using System.Diagnostics;

using Debug = UnityEngine.Debug;

public class Player : MonoBehaviour {

    private int maxHealth,
                currentHealth;

    private bool isDead,
                    isDamaged;

    // Movement speed
    private float distance = 13f;
    private float time = 5f;

	private Rigidbody2D rigid;
    private Animator anim;
    private Transform transf;

    private Vector3 startingPosition;
    private Vector2 input;

    private Movement movement;

    float t;

	void Awake () {
        maxHealth = 7;

        transf = GetComponent<Transform>();
		rigid = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

        movement = new Movement(distance, time, transf, anim);

        transf.position = startingPosition = new Vector3(-13, -4, 0);
        currentHealth = maxHealth;
        movement.MovementEnabled = true;
    }

	void Update(){
        HandleInputs();

        if(input.x != 0 || input.y != 0)
            movement.move(input);

        if (currentHealth == 0)
            Death();
    }

	void FixedUpdate () {
	}

    void OnCollisionEnter2D(Collision2D other) {

    }

    private void HandleInputs() {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        /*if (Input.GetButtonDown("Fire1") && Abilities[0].Useable) {
            Use(Abilities[0]);
        }
        if (Input.GetButtonDown("Fire2") && Abilities[1].Useable) {
            Use(Abilities[1]);
        }
        if (Input.GetButtonDown("Fire3") && Abilities[2].Useable) {
            Use(Abilities[2]);
        }
        if (Input.GetButtonDown("Jump") && Abilities[3].Useable) {
        Use(Abilities[3]);
        }*/
    }

    private void TakeDamage(int damage) {
        isDamaged = true;
    }

    private void Attack() {
        //use ability
    }

    private void Death() {
        isDead = true;
        movement.MovementEnabled = false;
        anim.SetBool("Death", isDead);
    }
        

    public int MaxHealth { get { return maxHealth; } }
    public int CurrentHealth { get; set; }
    public bool IsDead { get; set; }
    public bool IsDamaged { get; set; }
}
