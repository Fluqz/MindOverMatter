using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {

    private int maxHealth, currentHealth;
    private bool isDead, isDamaged;
    // Movement speed
    [SerializeField]
    private float distance = 13f, time = 5f;

	private Rigidbody2D rigid;
    private Animator anim;
    private Transform transf;
    private GameObject healthbar;

    private Vector3 startingPosition;
    private Vector2 startingDirection;
    private Vector2 input;

    private PlayerInput playerInput;
    private PlayerAbilities playerAbilities;

    void InitPlayer() {

        isDead = false;
        PlayerInformation.MaxHealth = PlayerInformation.CurrentHealth = currentHealth = maxHealth = 100;
        PlayerInformation.Name = "Kaphale";
        PlayerInformation.Description = "Brain Village guy";
        PlayerInformation.Distance = 25f;
        PlayerInformation.Time = 5f;
        PlayerInformation.PlayerGO = this.gameObject;
        PlayerInformation.Abilities = new Ability[4];

        playerAbilities.SetAbility(new Teleport(anim), 0);
        playerAbilities.SetAbility(new MindShield(anim), 1);
        playerAbilities.SetAbility(new EnergyShot(anim), 2);
        playerAbilities.SetAbility(new SwordThrust(anim), 3);
    }


    void Awake () {
        transf = GetComponent<Transform>();
		rigid = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
        healthbar = GameObject.Find("UI/Healthbar");

        playerInput = new PlayerInput();
        playerInput.Movement = new Movement(distance, time, transf, anim);
        playerAbilities = playerInput.PlayerAbilities;

        InitPlayer();
    }

    void Start() {
        startingDirection = new Vector2(0, -1);
        anim.SetFloat("DirectionX", startingDirection.x);
        anim.SetFloat("DirectionY", startingDirection.y);
        transf.position = startingPosition = new Vector3(-13, -4, 0);
        playerInput.Movement.MovementEnabled = true;
    }

	void Update() {
        playerInput.UpdateInput();
        PlayerInformation.Direction = new Vector2(anim.GetFloat("DirectionX"), anim.GetFloat("DirectionY"));

        if (currentHealth <= 0)
            Death();
    }

	void FixedUpdate () {
        //playerInput.Movement.UpdateVelocity(distance); // --------------------------> DELETE
	}


    public void TakeDamage(int damage) {
        currentHealth -= damage;
        isDamaged = true;
        healthbar.GetComponent<Healthbar>().ReduceHealthbar(currentHealth, maxHealth, 0);
    }

    private void BlockDamage(int damage) { }
    private void BlockDamage(int damage, Vector2 direction) { }

    private void Attack() {
        //use ability
    }

    private void Death() {
        playerInput.IsDead = isDead = true;
        playerInput.Movement.MovementEnabled = false;
        anim.SetBool("Death", isDead);
    }
        

    public int MaxHealth { get { return maxHealth; } }
    public int CurrentHealth { get; set; }
    public bool IsDead { get; set; }
    public bool IsDamaged { get; set; }
    public PlayerInput PlayerInput { get { return playerInput; } }
}
