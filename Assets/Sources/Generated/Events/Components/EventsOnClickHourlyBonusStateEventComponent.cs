//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class EventsEntity {

    public OnClickHourlyBonusStateEvent onClickHourlyBonusStateEvent { get { return (OnClickHourlyBonusStateEvent)GetComponent(EventsComponentsLookup.OnClickHourlyBonusStateEvent); } }
    public bool hasOnClickHourlyBonusStateEvent { get { return HasComponent(EventsComponentsLookup.OnClickHourlyBonusStateEvent); } }

    public void AddOnClickHourlyBonusStateEvent(bool newValue) {
        var index = EventsComponentsLookup.OnClickHourlyBonusStateEvent;
        var component = CreateComponent<OnClickHourlyBonusStateEvent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceOnClickHourlyBonusStateEvent(bool newValue) {
        var index = EventsComponentsLookup.OnClickHourlyBonusStateEvent;
        var component = CreateComponent<OnClickHourlyBonusStateEvent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveOnClickHourlyBonusStateEvent() {
        RemoveComponent(EventsComponentsLookup.OnClickHourlyBonusStateEvent);
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

    static Entitas.IMatcher<EventsEntity> _matcherOnClickHourlyBonusStateEvent;

    public static Entitas.IMatcher<EventsEntity> OnClickHourlyBonusStateEvent {
        get {
            if (_matcherOnClickHourlyBonusStateEvent == null) {
                var matcher = (Entitas.Matcher<EventsEntity>)Entitas.Matcher<EventsEntity>.AllOf(EventsComponentsLookup.OnClickHourlyBonusStateEvent);
                matcher.componentNames = EventsComponentsLookup.componentNames;
                _matcherOnClickHourlyBonusStateEvent = matcher;
            }

            return _matcherOnClickHourlyBonusStateEvent;
        }
    }
}
