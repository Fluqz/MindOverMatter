using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {

    public static Player Instance;

    Bleeding blood;


    private int maxHealth, currentHealth;
    private bool isDead, isDamaged;

    private float movementSpeed;

	private Rigidbody2D rigid;
    private Animator anim;
    private Transform transf;
    private Healthbar healthbar;

    private Vector2 startingDirection;
    private Vector2 input;

    private PlayerInput playerInput;
    private PlayerAbilities playerAbilities;

    private GameObject shit;


    void InitPlayer() {

        isDead = false;
        PlayerInformation.MaxHealth = PlayerInformation.CurrentHealth = currentHealth = maxHealth = 100;
        PlayerInformation.Name = "Kaphale";
        PlayerInformation.Description = "Brain Village guy";
        PlayerInformation.MovementSpeed = movementSpeed;
        PlayerInformation.PlayerGO = this.gameObject;
        PlayerInformation.Abilities = new Ability[4];

        playerAbilities.SetAbility(new SwordThrust(anim, 0), 0);
        playerAbilities.SetAbility(new Teleport(anim, 1), 1);
        playerAbilities.SetAbility(new EnergyShot(anim, 2), 2);
        playerAbilities.SetAbility(new MindShield(anim, 3), 3);
    }


    void Awake () {
        Instance = this;

		rigid = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
        transf = GetComponent<Transform>();
        healthbar = GameObject.Find("UI/Healthbar").GetComponent<Healthbar>();
        playerInput = new PlayerInput();
        playerAbilities = playerInput.PlayerAbilities;

        InitPlayer();
        playerInput.Movement = new PlayerMovement(movementSpeed, this.gameObject);


        shit = Resources.Load("Prefabs/Abilities/Shit") as GameObject;
    }

    void Start() {
        startingDirection = new Vector2(0, -1);
        anim.SetFloat("DirectionX", startingDirection.x);
        anim.SetFloat("DirectionY", startingDirection.y);
        //transf.position = startingPosition = new Vector3(-13, -4, 0);
        playerInput.Movement.MovementEnabled = true;
    }

	void Update() {
        PlayerInformation.Direction = new Vector2(anim.GetFloat("DirectionX"), anim.GetFloat("DirectionY"));
        PlayerInformation.Position = new Vector3(transf.position.x, transf.position.y, transf.position.y);
        transf.position = PlayerInformation.Position;

        if (Input.GetKeyDown(KeyCode.R)) {
            if (PlayerInformation.Items.Count > 0) {
                PlayerInformation.Items.RemoveAt(PlayerInformation.Items.Count - 1);
                Vector3 position = new Vector3(this.transf.position.x + ((-1) * (PlayerInformation.Direction.x * 1.5f)), this.transf.position.y + ((-1) * (PlayerInformation.Direction.y * 1.5f)), this.transf.position.y);

                GameObject shiet = Instantiate(shit, position, Quaternion.identity);
            }
        }

        playerInput.Update();

        if (currentHealth <= 0)
            Death();
    }

	void FixedUpdate () {
        playerInput.Move();
    }

    void OnGUI() {
        string text = "";
        if(PlayerInformation.Items.Count > 0)
            text = GUI.TextField(new Rect(400, 200, 100, 50), PlayerInformation.Items.Count.ToString());
        
    }

    public void TakeDamage(int damage, GameObject attacker) {
        Debug.Log(damage + "Damage on player with " + currentHealth);

        blood.CreateBloodSplatter(attacker, PlayerInformation.Direction);

        currentHealth -= damage;
        isDamaged = true;
        healthbar.ReduceHealthbar(currentHealth, maxHealth);
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
