using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoofCheck : DefaultMonoCollisionChecker
{
    protected override Vector3 CheckDirection => transform.up;

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

}
