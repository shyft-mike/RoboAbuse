using NUnit.Framework;
using UnityEngine;

public class HighlightableTest
{
    [Test]
    public void Highlightable_Defaults()
    {
        Color expectedHighlightColor = Color.green;

        GameObject gameObject = new GameObject();
        Highlightable highlightable = gameObject.AddComponent<Highlightable>();

        Assert.AreEqual(expectedHighlightColor, highlightable.HighlightColor);
        Assert.IsFalse(highlightable.HighlightEnabled);
    }

    // [UnityTest]
    // public IEnumerator Highlightable_SetHighlighted()
    // {
    //     bool highlightedValue = true;
    //     bool expectedHighlightEnabledResult = true;
    //     Color expectedColorResult = Color.green;

    //     GameObject testObject = GetStandardHighlightable();
    //     MeshRenderer mesh = testObject.GetComponent<MeshRenderer>();
    //     Highlightable highlightable = testObject.GetComponent<Highlightable>();

    //     yield return null;

    //     highlightable.Initialize();

    //     highlightable.SetHighlighted(highlightedValue);

    //     Assert.AreEqual(expectedHighlightEnabledResult, highlightable.HighlightEnabled);
    //     Assert.AreEqual(expectedColorResult, mesh.material.color);
    // }
}
