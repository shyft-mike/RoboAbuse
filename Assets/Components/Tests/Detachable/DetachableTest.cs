using NUnit.Framework;
using UnityEngine;

public class DetachableTest
{
    [Test]
    public void Detachable_GetDistanceFromAttachPosition()
    {
        float expectedResult = 1.0f;

        GameObject gameObject = new GameObject();
        Detachable testObject = gameObject.AddComponent<Detachable>();
        testObject.AttachPosition = new GameObject();

        float result = testObject.GetDistanceFromAttachPosition(new Vector3(1, 0, 0));

        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public void Detachable_IsWithinAttachRange_True()
    {
        bool expectedResult = true;

        AttachPoint attachPoint = new GameObject().AddComponent<AttachPoint>();
        attachPoint.transform.position = new Vector3(0, 1, 0);

        GameObject gameObject = new GameObject();
        Detachable testObject = gameObject.AddComponent<Detachable>();
        testObject.AttachPosition = new GameObject();
        testObject.AttachPosition.transform.position = new Vector3(0, -1, 0);

        bool result = testObject.IsWithinAttachRange(attachPoint);

        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public void Detachable_IsWithinAttachRange_False()
    {
        bool expectedResult = false;

        AttachPoint attachPoint = new GameObject().AddComponent<AttachPoint>();
        attachPoint.transform.position = new Vector3(0, 4, 0);

        GameObject gameObject = new GameObject();
        Detachable testObject = gameObject.AddComponent<Detachable>();
        testObject.AttachPosition = new GameObject();
        testObject.AttachPosition.transform.position = new Vector3(0, -1, 0);

        bool result = testObject.IsWithinAttachRange(attachPoint);

        Assert.AreEqual(expectedResult, result);
    }
}
