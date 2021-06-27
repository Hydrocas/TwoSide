using UnityEngine;

[CreateAssetMenu(fileName = "NewSeed", menuName = "TwoSide/Seed")]
public class SeedData : ScriptableObject
{
    [SerializeField] private CharacterType type = default;
    [SerializeField] private Sprite sprite = null;
    [SerializeField] private Flower flower = null;
}
