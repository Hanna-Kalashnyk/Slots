//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class EventsEntity {

    static readonly DeletionMarkComponent deletionMarkComponent = new DeletionMarkComponent();

    public bool isDeletionMark {
        get { return HasComponent(EventsComponentsLookup.DeletionMark); }
        set {
            if (value != isDeletionMark) {
                if (value) {
                    AddComponent(EventsComponentsLookup.DeletionMark, deletionMarkComponent);
                } else {
                    RemoveComponent(EventsComponentsLookup.DeletionMark);
                }
            }
        }
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
public sealed partial class EventsMatcher {

    static Entitas.IMatcher<EventsEntity> _matcherDeletionMark;

    public static Entitas.IMatcher<EventsEntity> DeletionMark {
        get {
            if (_matcherDeletionMark == null) {
                var matcher = (Entitas.Matcher<EventsEntity>)Entitas.Matcher<EventsEntity>.AllOf(EventsComponentsLookup.DeletionMark);
                matcher.componentNames = EventsComponentsLookup.componentNames;
                _matcherDeletionMark = matcher;
            }

            return _matcherDeletionMark;
        }
    }
}