using UnityEngine;

[CreateAssetMenu(fileName = "NewSeed", menuName = "TwoSide/Seed")]
public class SeedData : ScriptableObject
{
    public CharacterType type = default;
    public Sprite sprite = null;
    public Flower flower = null;
}
