using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
public abstract class DefaultMonoCollisionChecker : MonoBehaviour, ICollisionCheck
{
    [SerializeField] protected float checkDistance = 0.1f;
    [SerializeField] protected float maxDistance = 0.01f;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float angleLimit = 45;
    [SerializeField] Color color = Color.blue;

    new protected Collider2D collider;
    protected Vector3[] positions;
    protected Animator animator;


    public bool IsInCollision { get; private set; }
    public bool IsReallyInCollision { get { return IsInCollision && collider.IsTouching(CurrentCollisionCollider); } }
    public Vector2 Normal { get; private set; }
    public GameObject CurrentCollisionObject { get; private set; }
    public Collider2D CurrentCollisionCollider { get; private set; }
    protected abstract Vector3 CheckDirection {  get; }


    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        StartRayPositions();
    }
    protected abstract void StartRayPositions();


    private void Update()
    {
        foreach (Vector3 position in positions)
        {
            CheckForCollision(collider.bounds.center + position, CheckDirection);
            if (IsInCollision)
                break;
        }
        UpdateAnimator();
    }

    private void CheckForCollision(Vector3 position,Vector3 direction)
    {
        var raycastHit = Physics2D.Raycast(position, direction, maxDistance, layerMask);
        Debug.DrawRay(position, direction * maxDistance, color);


        if (raycastHit.collider != null &&
            Vector3.Angle(direction * -1, raycastHit.normal) <= angleLimit &&
            raycastHit.distance > 0.01f)
        {
            Normal = raycastHit.normal;
            CurrentCollisionObject = raycastHit.collider.gameObject;
            CurrentCollisionCollider = raycastHit.collider;
            IsInCollision = true;
        }
        else
        {
            CurrentCollisionObject = null;
            CurrentCollisionCollider = null;
            IsInCollision = false;
        }
    }

    protected virtual void UpdateAnimator() { }
}
