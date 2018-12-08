using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine.Events;

[Core]
[Unique]
public class FeaturesModel : IComponent
{
    public Dictionary<string, IGameFeature> map;
    public Dictionary<string, UnityAction> entryFeatures;
}