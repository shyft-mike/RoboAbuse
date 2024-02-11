using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// A component which initiates and handles highlighting of Highlightables.
/// </summary>
public class Highlighter : MonoBehaviour
{
    /// <summary>
    /// The collection of Highlightables affected by the Highlighter.
    /// </summary>
    public List<Highlightable> Highlightables;

    void Start()
    {
        Initialize();
    }

    /// <summary>
    /// Initialize the Highlighter.
    /// </summary>
    public void Initialize()
    {
        // Sanity check.
        MeshCollider collider = GetComponent<MeshCollider>();
        Assert.IsNotNull(collider, $"Highlighter [{gameObject.name}] has no collider.");
    }

    void Update()
    {

    }

    /// <summary>
    /// The mouse over handler.
    /// </summary>
    void OnMouseOver()
    {
        foreach (Highlightable highlightable in Highlightables)
        {
            highlightable.SetHighlighted(true);
        }
    }

    /// <summary>
    /// The mouse exit handler.
    /// </summary>
    void OnMouseExit()
    {
        foreach (Highlightable highlightable in Highlightables)
        {
            highlightable.SetHighlighted(false);
        }
    }

    /// <summary>
    /// Handle when an object is detached.
    /// </summary>
    /// <param name="detachEventParams"></param>
    public void HandleDetachEvent(DetachEventParams detachEventParams)
    {
        // Find all highlightables and either remove them from or add them to the list of Highlightables.
        Highlightable[] detachedHighlightables = detachEventParams.DetachedObject.GetComponentsInChildren<Highlightable>();

        foreach (Highlightable detachedHighlightable in detachedHighlightables)
        {
            if (detachEventParams.IsDetached)
            {
                Highlightables.Remove(detachedHighlightable);
            }
            else
            {
                if (!Highlightables.Contains(detachedHighlightable))
                {
                    Highlightables.Add(detachedHighlightable);
                }
            }
        }
    }
}
