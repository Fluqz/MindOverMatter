using UnityEngine;
using System.Collections;

public class AbilityCollision : MonoBehaviour {

    private Ability ability;
    private CollisionDamage collisionBehaviour;
    private SpaceTravel spaceTravelBehaviour;

    private Animator anim;
    private GameObject user;

    private PolygonCollider2D[] polygonColliders;

    RaycastHit2D hit;

    Vector2 direction;

    public void Action(Ability ability) {
        this.ability = ability;
        collisionBehaviour = FindAbility.GetAbilityBehaviour("Collision Damage", ability) as CollisionDamage;
        this.spaceTravelBehaviour = FindAbility.GetAbilityBehaviour("Space Travel", ability) as SpaceTravel;

        polygonColliders = user.GetComponents<PolygonCollider2D>();

        if (user.CompareTag("Player")) {
            Player player = user.GetComponent<Player>();
            direction = PlayerInformation.Direction;
        }
        else if (user.CompareTag("Enemy")) {
            Enemy enemy = user.GetComponent<Enemy>();
            direction = enemy.EnemyInfo.Direction;
        }

        RayCast();
    }
	
    void Update() {
        if (hit)
            Debug.DrawLine(this.transform.position, hit.point);
    }

	void RayCast() {
        string tag = ability.GetOppositeTag(user.tag);
        int layer = LayerMask.NameToLayer(tag);
        hit = Physics2D.Raycast(transform.position, direction, spaceTravelBehaviour.Distance, 1 << layer);

        if (hit.collider == null)
            return;
        else {
            if (tag == "Enemy") {
                hit.collider.GetComponentInParent<Enemy>().TakeDamage(ability.Damage);
            }
            else hit.collider.GetComponent<Player>().TakeDamage(ability.Damage, user);
        }
	}

    public GameObject User { get { return user; } set { user = value; } }
}
