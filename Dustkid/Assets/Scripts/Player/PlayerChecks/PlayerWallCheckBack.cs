using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallCheckBack : DefaultMonoCollisionChecker
{
    [SerializeField] float offsetY = 0.2f;

    protected override Vector3 CheckDirection => transform.right * -1;

    protected override void StartRayPositions()
    {
        int numberOfRays = Mathf.CeilToInt((collider.bounds.max.y - 2 * offsetY - collider.bounds.min.y) / checkDistance) + 1;
        float offserCenterY = collider.bounds.min.y - collider.bounds.center.y;
        positions = new Vector3[numberOfRays];
        maxDistance = GetComponent<Collider2D>().bounds.extents.x + 0.1f;
        for (int i = 0; i < numberOfRays; i++)
        {
            float yValue = (collider.bounds.min.y + offsetY + checkDistance * i <= collider.bounds.max.y - offsetY) ? checkDistance * i + offserCenterY + offsetY : collider.bounds.max.y - collider.bounds.center.y - offsetY;
            positions[i] = new Vector3(0, yValue);
        }
    }
}
