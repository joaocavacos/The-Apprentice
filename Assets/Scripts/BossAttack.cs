using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public int damage;

    public Vector3 attackOffset;
    public float attackRange;
    public LayerMask isPlayer;

    Collider2D colInfo;

    public void Attack()
	{
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        colInfo = Physics2D.OverlapCircle(pos, attackRange, isPlayer);

        if(colInfo != null)
		{
            StartCoroutine(timebtwAttack());
		}
	}

	void OnDrawGizmos()
	{
        Vector3 pos = transform.position;

        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
	}

    private IEnumerator timebtwAttack()
	{
        colInfo.GetComponent<HealthSystem>().TakeDamage(damage);
        yield return new WaitForSeconds(1f);
    }
}
