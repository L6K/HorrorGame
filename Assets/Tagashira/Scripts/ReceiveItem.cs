
public interface ReceiveItem
{
    /// <summary>
    /// アイテムを使用された際に行う動作
    /// </summary>
    public abstract void ReceiveAciton();

    /// <summary>
    /// Story情報を取得する
    /// </summary>
    public abstract void GetStory();

    /// <summary>
    /// Indexを取得する
    /// </summary>
    public abstract void GetIndex();
}
