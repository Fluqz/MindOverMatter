using UnityEngine;
using System.Collections;

public class PlayerInput {

    private Movement movement;
    private PlayerAbilities playerAbilities;

    private Vector2 input;

    private bool inGame;
    private bool isDead;

    public PlayerInput() {
        playerAbilities = new PlayerAbilities();
        inGame = true;
        isDead = false;
    }

    public void FixedUpdate() {
        if (!isDead && inGame) {

            Move();

            Ability1();
            Ability2();
            Ability3();
            Ability4();

            
        }
    }

    // WALK - LeftStick
    public void Move() {
        this.input.x = Input.GetAxisRaw("Horizontal");
        this.input.y = Input.GetAxisRaw("Vertical");
        movement.Move(this.input);
        movement.SetPlayerDirection();
    }

    // 
    public void RightStick(Vector2 input) { }

    // A 
   public void Ability1() {
        if (Input.GetButtonDown("Fire1") && PlayerInformation.Abilities[0].Useable) {
            Debug.Log(PlayerInformation.Abilities[0].Name + " " + PlayerInformation.Abilities[0].Index);
            playerAbilities.UseAbility(PlayerInformation.Abilities[0]);
        }
    }
    // B
    public void Ability2() {
        if (Input.GetButtonDown("Fire2") && PlayerInformation.Abilities[1].Useable) {
            Debug.Log(PlayerInformation.Abilities[1].Name + " " + PlayerInformation.Abilities[1].Index);
            playerAbilities.UseAbility(PlayerInformation.Abilities[1]);
        }
    }
    // Y
    public void Ability3() {
        if (Input.GetButton("Jump") && PlayerInformation.Abilities[2].Useable) {
            Debug.Log(PlayerInformation.Abilities[2].Name + " " + PlayerInformation.Abilities[2].Index);
            playerAbilities.UseAbility(PlayerInformation.Abilities[2]);
        }
    }
    // X
    public void Ability4() {
        if (Input.GetButtonDown("Fire3") && PlayerInformation.Abilities[3].Useable) {
            Debug.Log(PlayerInformation.Abilities[3].Name + " " + PlayerInformation.Abilities[3].Index);
            playerAbilities.UseAbility(PlayerInformation.Abilities[3]);
        }
    }

    // 
    public void RightTrigger() { }
    //
    public void LeftTrigger() { }
    //
    public void RightBumper() { }
    // Left Bumper
    public void ControlEnemy() { }
    //
    public void StartButton() { }
    //
    public void BackButton() { }
    


    public Movement Movement { get { return movement; } set { movement = value; } }
    public PlayerAbilities PlayerAbilities { get { return playerAbilities; } set { playerAbilities = value; } }
    public bool IsDead { get { return isDead; } set { isDead = value; } }
    public bool InGame { get { return inGame; } set { inGame = value; } }
}
