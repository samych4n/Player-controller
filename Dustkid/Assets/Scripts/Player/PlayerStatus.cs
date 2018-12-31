using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] float dashDistance = 10;
    [SerializeField] float dashTime = 3f;

    [SerializeField] int airJumps = 2;
    int airJumpsRemains;



    public float DashDistance { get { return dashDistance; } }
    public float DashTime { get { return dashTime; } }
    public bool IsAirJumpAvailable { get { return airJumpsRemains > 0; } }
    public bool IsAirDashAvailable { get { return airJumpsRemains > 0; } }

    private void Awake()
    {
        airJumpsRemains = airJumps;
    }

    public void ResetAirJumps()
    {
        airJumpsRemains = airJumps;
    }

    public void AirJump()
    {
        airJumpsRemains--;
    }

    public void AirDash()
    {
        airJumpsRemains--;
    }



}
