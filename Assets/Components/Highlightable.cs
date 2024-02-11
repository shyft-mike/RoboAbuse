using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// A component which can be highlighted.
/// </summary>
public class Highlightable : MonoBehaviour
{
    /// <summary>
    /// The color to highlight with. Could be an entire material.
    /// </summary>
    public Color HighlightColor = Color.green;

    /// <summary>
    /// Whether the highlighting is enabled.
    /// </summary>
    public bool HighlightEnabled = false;

    /// <summary>
    /// The original color of the object.
    /// </summary>
    private Color _originalColor;

    /// <summary>
    /// The material of the object.
    /// </summary>
    private Material _material;

    void Start()
    {
        Initialize();
    }

    /// <summary>
    /// Initialize the Highlightable.
    /// </summary>
    public void Initialize()
    {
        // Sanity check.
        MeshRenderer _renderer = GetComponent<MeshRenderer>();
        Assert.IsNotNull(_renderer, "Highlightable object does not have a MeshRenderer.");

        _material = _renderer.material;
        _originalColor = _material.color;
    }

    void Update()
    {

    }

    /// <summary>
    /// Sets the object's highlight value.
    /// </summary>
    /// <param name="highlight">Whether the object is highlighted.</param>
    public void SetHighlighted(bool highlight)
    {
        HighlightEnabled = highlight;

        if (HighlightEnabled)
        {
            _material.color = HighlightColor; // Use the highlight color.
        }
        else
        {
            _material.color = _originalColor; // Use the original material color.
        }
    }
}
