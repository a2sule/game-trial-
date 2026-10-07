using UnityEngine;

public class CombatController : MonoBehaviour
{
    public Camera cam;
    public float range = 2.2f;
    public float damage = 25f;
    public float cooldown = .45f;
    private float nextAttack;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextAttack)
        {
            nextAttack = Time.time + cooldown;
            Attack();
        }
    }

    private void Attack()
    {
        Vector3 origin = transform.position + Vector3.up * 1.2f;
        Vector3 dir = transform.forward;
        if (Physics.Raycast(origin,dir,out RaycastHit hit,range))
        {
            Health h = hit.collider.GetComponentInParent<Health>();
            if (h && h.gameObject != gameObject)
            {
                h.Damage(damage);
                GameManager.Instance?.AddWanted(1);
            }
        }
    }
}
