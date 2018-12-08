public interface IGameFeature
{
    string Name { get; }
    void Activate();
    void Deactivate();
    bool isActive { get; }
    Contexts contexts { get; }
}
