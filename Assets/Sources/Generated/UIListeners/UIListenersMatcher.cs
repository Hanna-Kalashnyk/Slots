//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class UIListenersMatcher {

    public static Entitas.IAllOfMatcher<UIListenersEntity> AllOf(params int[] indices) {
        return Entitas.Matcher<UIListenersEntity>.AllOf(indices);
    }

    public static Entitas.IAllOfMatcher<UIListenersEntity> AllOf(params Entitas.IMatcher<UIListenersEntity>[] matchers) {
          return Entitas.Matcher<UIListenersEntity>.AllOf(matchers);
    }

    public static Entitas.IAnyOfMatcher<UIListenersEntity> AnyOf(params int[] indices) {
          return Entitas.Matcher<UIListenersEntity>.AnyOf(indices);
    }

    public static Entitas.IAnyOfMatcher<UIListenersEntity> AnyOf(params Entitas.IMatcher<UIListenersEntity>[] matchers) {
          return Entitas.Matcher<UIListenersEntity>.AnyOf(matchers);
    }
}
