public interface IPlayerState 
{
    void OnEnter();
    void OnExit();
    void Update(IInput input, float deltaTime);
    void FixedUpdate(IInput input, float deltaTime);
    PlayerStateMachine MyStateMachine { get; }
}
