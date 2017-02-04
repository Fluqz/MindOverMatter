using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {

    public GameObject energyShotPrefab;

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
    private Vector2 startingDirection;
    private Vector2 input;

    private PlayerInput playerInput;
    private PlayerAbilities playerAbilities;

    public void InitPlayer() {
        PlayerInformation.Name = "Kaphale";
        PlayerInformation.Description = "Brain Village guy";
        PlayerInformation.Distance = 13f;
        PlayerInformation.Time = 5f;
        PlayerInformation.PlayerGO = this.gameObject;
        PlayerInformation.Abilities = new Ability[4];
    }


    void Awake () {
        maxHealth = 7;
        InitPlayer();

        transf = GetComponent<Transform>();
		rigid = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

        playerInput = new PlayerInput();
        playerInput.Movement = new Movement(distance, time, transf, anim);
        playerAbilities = playerInput.PlayerAbilities;

        playerAbilities.AddOrReplaceAbility(new Teleport(), 0);
        playerAbilities.AddOrReplaceAbility(new MindShield(), 1);
        playerAbilities.AddOrReplaceAbility(new EnergyShot(energyShotPrefab), 2);
        playerAbilities.AddOrReplaceAbility(new SwordThrust(), 3);

        startingDirection = new Vector2(0, -1);
        transf.position = startingPosition = new Vector3(-13, -4, 0);
        currentHealth = maxHealth;
        playerInput.Movement.MovementEnabled = true;
    }

    void Start() {
        anim.SetFloat("x", startingDirection.x);
        anim.SetFloat("y", startingDirection.y);
    }

	void Update() {
        playerInput.UpdateInput();


        if (currentHealth == 0)
            Death();
    }

	void FixedUpdate () {
	}


    void OnCollisionEnter2D(Collision2D other) {

    }

    private void TakeDamage(int damage) {
        isDamaged = true;
    }

    private void BlockDamage(int damage) { }
    private void BlockDamage(int damage, Vector2 direction) { }

    private void Attack() {
        //use ability
    }

    private void Death() {
        isDead = true;
        playerInput.Movement.MovementEnabled = false;
        anim.SetBool("Death", isDead);
    }
        

    public int MaxHealth { get { return maxHealth; } }
    public int CurrentHealth { get; set; }
    public bool IsDead { get; set; }
    public bool IsDamaged { get; set; }
}
