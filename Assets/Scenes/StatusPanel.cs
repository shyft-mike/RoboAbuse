using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A component for managing a status panel. Currently lists detach/attach data.
/// </summary>
public class StatusPanel : MonoBehaviour
{
    /// <summary>
    /// The template object for adding text to the StatusPanel.
    /// </summary>
    public GameObject StatusTextTemplate;

    /// <summary>
    /// The collection of Detachable objects and their status text.
    /// </summary>
    private Dictionary<string, Text> _detachables = new Dictionary<string, Text>();

    void Start()
    {

    }

    void Update()
    {

    }

    /// <summary>
    /// Handles the DetachEvent.
    /// </summary>
    /// <param name="detachEventParams">The DetachEventParams.</param>
    public void HandleDetachEvent(DetachEventParams detachEventParams)
    {
        // Look up the existing object name.
        string objectName = detachEventParams.DetachedObject.name;
        Text statusText = _detachables.GetValueOrDefault(objectName);

        if (statusText == null)
        {
            // If it doesn't exist, clone the text template and set up the new object.
            GameObject newTextGameobject = Instantiate(StatusTextTemplate);
            newTextGameobject.SetActive(true);
            newTextGameobject.transform.SetParent(transform);
            statusText = newTextGameobject.GetComponent<Text>();
            _detachables.Add(objectName, statusText);
        }

        statusText.text = $"{objectName} - {(detachEventParams.IsDetached ? "DETACHED" : "ATTACHED")}";
        statusText.color = detachEventParams.IsDetached ? Color.red : Color.green;
    }
}
