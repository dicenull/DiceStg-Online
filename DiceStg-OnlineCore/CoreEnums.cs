namespace DiceStg_Online.Core
{
    /// <summary>
    /// プレイヤーの行動列挙
    /// </summary>
    public enum ActionState
    {
        MoveUp,
        MoveDown,
        MoveLeft,
        MoveRight,
        Shot,
        DoNothing
    }

    /// <summary>
    /// 方向を列挙
    /// </summary>
    public enum DirectionState
    {
        Up = 0, Down, Left, Right
    }

    /// <summary>
    /// 定義された色
    /// </summary>
    public enum Palette
    {
        Red = 0,
        Green,
        Blue,
        Yellow,
        Black,
        White,
    }
}
