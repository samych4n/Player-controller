public interface IInput
{
    KeyButton DashButton { get; }
    KeyButton JumpButton { get; }
    KeyButton WeakAttackButton { get; }
    KeyButton HeavyAttackButton { get; }
    float Horizontal { get; }
    float Vertical { get; }
}
