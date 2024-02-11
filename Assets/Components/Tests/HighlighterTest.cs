using NUnit.Framework;
using UnityEngine;

public class HighlighterTest
{
    [Test]
    public void Highlighter_Initialize()
    {
        GameObject gameObject = new GameObject();
        gameObject.AddComponent<MeshCollider>();
        Highlighter testObject = gameObject.AddComponent<Highlighter>();

        testObject.Initialize();

        Assert.Pass("Highlighter successfully called Initialize()");
    }

    [Test]
    public void Highlighter_Initialize_ShouldHaveCollider()
    {
        GameObject gameObject = new GameObject();
        Highlighter testObject = gameObject.AddComponent<Highlighter>();

        Assert.Throws<UnityEngine.Assertions.AssertionException>(testObject.Initialize);
    }
}
