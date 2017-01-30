using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Xml.Linq;
using System.Configuration;

public enum State{
	Ready,
	Action,
	Cooldown
}

public class Flash : Ability {
    
	private State ts;
    private Animator anim;

    private const string name = "Teleport",
                            description = "An instant travel throughout space";

	private int abilityID = 1;
	public float teleportRange = 2f;
	public float cooldown = 3;
    private float teleportTime = 0.4f;
    private bool isTeleporting = false;

	private float time = 0;

    public Flash() : 
        base(new BasicObjectInformation(name, description)) { 
    }

    void Start() {
        anim = GetComponent<Animator>();
    }

	void Update () {
		float horizontal = Input.GetAxisRaw ("Horizontal");
		float vertical = Input.GetAxisRaw ("Vertical");

		switch(ts){
		case State.Ready:
			if (Input.GetButtonDown ("Fire1")) {
                isTeleporting = true;
                anim.SetBool("isTeleporting", isTeleporting);
				transform.Translate (new Vector3(horizontal, vertical, 0));
                time = 0;
				ts = State.Action;
			}
		break;

		case State.Action:
            time += Time.deltaTime;
                
            if(time >= teleportTime) {
                time = 0;
                ts = State.Cooldown;
            }
		break;

		case State.Cooldown:
            isTeleporting = false;
            anim.SetBool("isTeleporting", isTeleporting);
            time += Time.deltaTime;

			if (time >= (cooldown - teleportTime)) {
				time = 0;
				ts = State.Ready;
			}
		break;		
		}
	}
}
