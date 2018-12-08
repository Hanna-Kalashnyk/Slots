//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CoreEntity {

    public GameFeatureComponent gameFeature { get { return (GameFeatureComponent)GetComponent(CoreComponentsLookup.GameFeature); } }
    public bool hasGameFeature { get { return HasComponent(CoreComponentsLookup.GameFeature); } }

    public void AddGameFeature(IGameFeature newFeature) {
        var index = CoreComponentsLookup.GameFeature;
        var component = CreateComponent<GameFeatureComponent>(index);
        component.feature = newFeature;
        AddComponent(index, component);
    }

    public void ReplaceGameFeature(IGameFeature newFeature) {
        var index = CoreComponentsLookup.GameFeature;
        var component = CreateComponent<GameFeatureComponent>(index);
        component.feature = newFeature;
        ReplaceComponent(index, component);
    }

    public void RemoveGameFeature() {
        RemoveComponent(CoreComponentsLookup.GameFeature);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class CoreMatcher {

    static Entitas.IMatcher<CoreEntity> _matcherGameFeature;

    public static Entitas.IMatcher<CoreEntity> GameFeature {
        get {
            if (_matcherGameFeature == null) {
                var matcher = (Entitas.Matcher<CoreEntity>)Entitas.Matcher<CoreEntity>.AllOf(CoreComponentsLookup.GameFeature);
                matcher.componentNames = CoreComponentsLookup.componentNames;
                _matcherGameFeature = matcher;
            }

            return _matcherGameFeature;
        }
    }
}
