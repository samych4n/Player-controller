using UnityEngine;

public class PlayerGroundCheck : DefaultMonoCollisionChecker
{
    protected override Vector3 CheckDirection => transform.up * -1;

    protected override void StartRayPositions()
    {
        int numberOfRays = Mathf.CeilToInt((collider.bounds.max.x - collider.bounds.min.x) / checkDistance) + 1;
        float offserCenterX = collider.bounds.min.x - collider.bounds.center.x;
        positions = new Vector3[numberOfRays];
        maxDistance = GetComponent<Collider2D>().bounds.extents.y + 0.1f;
        for (int i = 0; i < numberOfRays; i++)
        {
            float xValue = (collider.bounds.min.x + checkDistance * i <= collider.bounds.max.x) ? checkDistance * i + offserCenterX : collider.bounds.max.x - collider.bounds.center.x;
            positions[i] = new Vector3(xValue, 0);
        }
    }
    protected override void UpdateAnimator()
    {
        animator.SetBool("IsGrounded", IsInCollision);
    }
}
