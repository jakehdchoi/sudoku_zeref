
using UnityEngine;
using TMPro;

public class Cell : MonoBehaviour
{
    [HideInInspector] public int Value;
    [HideInInspector] public int Row;
    [HideInInspector] public int Col;
    [HideInInspector] public bool IsLocked;
    [HideInInspector] public bool IsIncorrect;

    [SerializeField] private SpriteRenderer _backgroundSprite;
    [SerializeField] private TMP_Text _valueText;

    [SerializeField] private Color _startUnlockedCellColor;
    [SerializeField] private Color _startUnlockedTextColor;
    [SerializeField] private Color _startLockedCellColor;
    [SerializeField] private Color _startLockedTextColor;

    public void Init(int value)
    {
        IsIncorrect = false;
        Value = value;

        if (value == 0)
        {
            IsLocked = false;
            _backgroundSprite.color = _startUnlockedCellColor;
            _valueText.color = _startUnlockedTextColor;
            _valueText.text = "";
        }
        else
        {
            IsLocked = true;
            _backgroundSprite.color = _startLockedCellColor;
            _valueText.color = _startLockedTextColor;
            _valueText.text = Value.ToString();
        }
    }
}
