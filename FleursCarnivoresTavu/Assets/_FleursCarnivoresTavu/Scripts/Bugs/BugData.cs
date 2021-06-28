using UnityEngine;

[CreateAssetMenu(fileName = "NewBug", menuName = "TwoSide/Bug")]
public class BugData : ScriptableObject
{
    [SerializeField] private CharacterType type = default;
    [SerializeField] private Sprite sprite = null;
    [SerializeField] private RuntimeAnimatorController animatorController = null;

    public CharacterType Type => type;

    public Sprite Sprite => sprite;

    public RuntimeAnimatorController AnimatorController => animatorController;
}
