using UnityEngine;
using System.Collections;

public class PlayerInput {

    private Movement movement;
    public Movement Movement { get { return movement; } set { movement = value; } }

    private PlayerAbilities playerAbilities;
    public PlayerAbilities PlayerAbilities { get { return playerAbilities; } set { playerAbilities = value; } }

    private Vector2 input;

    private bool inGame;

    public PlayerInput() {
        playerAbilities = new PlayerAbilities();
        inGame = true;
    }

    public void UpdateInput() {
        this.input.x = Input.GetAxisRaw("Horizontal");
        this.input.y = Input.GetAxisRaw("Vertical");


        if (input.x != 0 || input.y != 0)
            Move();

        Ability1();
        Ability2();
        Ability3();
        Ability4();
    }

    // WALK - LeftStick
    public void Move() {
        movement.move(this.input);
    }

    // 
    public void RightStick(Vector2 input) { }

    // A 
   public void Ability1() {
        if (Input.GetButtonDown("Fire1") && PlayerInformation.Abilities[0].Useable) {
            Debug.Log("A");
            Debug.Log(PlayerInformation.Abilities[0].AbilityInfo.ObjectName);
            playerAbilities.UseAbility(PlayerInformation.Abilities[0]);
        }
    }
    // B
    public void Ability2() {
        if (Input.GetButtonDown("Fire2") && PlayerInformation.Abilities[1].Useable) {
            Debug.Log("B");
            Debug.Log(PlayerInformation.Abilities[1].AbilityInfo.ObjectName);
            playerAbilities.UseAbility(PlayerInformation.Abilities[1]);
        }
    }
    // Y
    public void Ability3() {
        if (Input.GetButtonDown("Jump") && PlayerInformation.Abilities[2].Useable) {
            Debug.Log("Y");
            Debug.Log(PlayerInformation.Abilities[2].AbilityInfo.ObjectName);
            playerAbilities.UseAbility(PlayerInformation.Abilities[2]);
        }
    }
    // X
    public void Ability4() {
        if (Input.GetButtonDown("Fire3") && PlayerInformation.Abilities[3].Useable) {
            Debug.Log("X");
            Debug.Log(PlayerInformation.Abilities[3].AbilityInfo.ObjectName);
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
}
