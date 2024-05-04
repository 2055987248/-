using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeadMove : MonoBehaviour
{
    // Start is called before the first frame update

    public float beadSpacing;
    private RaycastHit2D[] hits;
    public void OnClickBead()
    {
        hits = new RaycastHit2D[0];
        MoveBead(transform.position);
    }

    private void MoveBead(Vector2 currentPosition)
    {
        hits = Physics2D.RaycastAll(transform.position, Vector2.up, beadSpacing * 5);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null && hit.collider.gameObject != gameObject)
            {
                BeadMove bead = hit.collider.gameObject.GetComponent<BeadMove>();
                if (bead != null)
                {
                    bead.Move();
                }
            }
        }
        Move();
    }
    private void Move()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + beadSpacing * 4);
    }
}
