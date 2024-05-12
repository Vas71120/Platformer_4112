using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    [SerializeField] private string title;
    [SerializeField] private Sprite sprite;
    [SerializeField, Min(0)] private int maxAmount = 10;

    [TextArea(3, 10)]
    [SerializeField] private string description;

    public string Title => title;
    public Sprite Sprite => sprite;
    public int MaxAmount => maxAmount;
    public string Description => description;
}
