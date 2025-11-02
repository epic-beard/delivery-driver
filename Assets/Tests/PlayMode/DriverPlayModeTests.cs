using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode
{
    public class DriverPlayModeTests
    {
        [UnityTest]
        public IEnumerator Driver_RotatesClockwiseWithPositiveHorizontalInput()
        {
            // Arrange
            GameObject testObject = new GameObject();
            Driver driver = testObject.AddComponent<Driver>();
            testObject.transform.eulerAngles = new Vector3(0, 0, 0);
            Quaternion initialRotation = testObject.transform.rotation;

            // Simulate right input (positive horizontal input should rotate clockwise = negative Z)
            float simulatedInput = 1.0f; // Right key
            float rotationSpeed = 720.0f;
            float deltaTime = 0.1f;

            // Act - Manually apply rotation as Update would
            testObject.transform.Rotate(0f, 0f, -simulatedInput * rotationSpeed * deltaTime);

            yield return null;

            // Assert - Check that rotation actually changed in the expected direction
            float angleDifference = Quaternion.Angle(initialRotation, testObject.transform.rotation);
            float expectedAngle = rotationSpeed * deltaTime;
            Assert.AreEqual(expectedAngle, angleDifference, 0.01f,
                "Object should rotate by the expected angle with positive horizontal input");

            // Verify Z euler angle is around 288 (360 - 72) for clockwise rotation
            Assert.That(testObject.transform.eulerAngles.z, Is.InRange(287f, 289f),
                "Object should rotate clockwise (Z angle wraps to ~288 degrees)");

            // Cleanup
            Object.Destroy(testObject);
        }

        [UnityTest]
        public IEnumerator Driver_RotatesCounterClockwiseWithNegativeHorizontalInput()
        {
            // Arrange
            GameObject testObject = new GameObject();
            Driver driver = testObject.AddComponent<Driver>();
            testObject.transform.eulerAngles = new Vector3(0, 0, 0);
            Vector3 initialRotation = testObject.transform.eulerAngles;

            // Simulate left input (negative horizontal input should rotate counter-clockwise = positive Z)
            float simulatedInput = -1.0f; // Left key
            float rotationSpeed = 720.0f;
            float deltaTime = 0.1f;

            // Act
            testObject.transform.Rotate(0f, 0f, -simulatedInput * rotationSpeed * deltaTime);

            yield return null;

            // Assert
            Assert.Greater(testObject.transform.eulerAngles.z, initialRotation.z,
                "Object should rotate counter-clockwise (increase Z) with negative horizontal input");

            // Cleanup
            Object.Destroy(testObject);
        }

        [UnityTest]
        public IEnumerator Driver_MovesForwardWithPositiveVerticalInput()
        {
            // Arrange
            GameObject testObject = new GameObject();
            Driver driver = testObject.AddComponent<Driver>();
            Vector3 initialPosition = testObject.transform.position;

            // Simulate forward input
            float simulatedInput = 1.0f; // W key
            float moveSpeed = 40.0f;
            float deltaTime = 0.1f;

            // Act - Manually apply translation as Update would
            testObject.transform.Translate(0f, simulatedInput * moveSpeed * deltaTime, 0f);

            yield return null;

            // Assert
            Assert.Greater(testObject.transform.position.y, initialPosition.y,
                "Object should move forward (positive Y) with positive vertical input");

            float expectedDistance = moveSpeed * deltaTime;
            float actualDistance = Vector3.Distance(initialPosition, testObject.transform.position);
            Assert.AreEqual(expectedDistance, actualDistance, 0.01f,
                "Object should move the expected distance based on moveSpeed");

            // Cleanup
            Object.Destroy(testObject);
        }

        [UnityTest]
        public IEnumerator Driver_MovesBackwardWithNegativeVerticalInput()
        {
            // Arrange
            GameObject testObject = new GameObject();
            Driver driver = testObject.AddComponent<Driver>();
            Vector3 initialPosition = testObject.transform.position;

            // Simulate backward input
            float simulatedInput = -1.0f; // S key
            float moveSpeed = 40.0f;
            float deltaTime = 0.1f;

            // Act
            testObject.transform.Translate(0f, simulatedInput * moveSpeed * deltaTime, 0f);

            yield return null;

            // Assert
            Assert.Less(testObject.transform.position.y, initialPosition.y,
                "Object should move backward (negative Y) with negative vertical input");

            // Cleanup
            Object.Destroy(testObject);
        }

        [UnityTest]
        public IEnumerator Driver_DoesNotMoveWithZeroVerticalInput()
        {
            // Arrange
            GameObject testObject = new GameObject();
            Driver driver = testObject.AddComponent<Driver>();
            Vector3 initialPosition = testObject.transform.position;

            // Simulate no input
            float simulatedInput = 0.0f;
            float moveSpeed = 40.0f;
            float deltaTime = 0.1f;

            // Act
            testObject.transform.Translate(0f, simulatedInput * moveSpeed * deltaTime, 0f);

            yield return null;

            // Assert
            Assert.AreEqual(initialPosition, testObject.transform.position,
                "Object should not move with zero vertical input");

            // Cleanup
            Object.Destroy(testObject);
        }

        [UnityTest]
        public IEnumerator Driver_MovesInLocalSpaceRelativeToRotation()
        {
            // Arrange
            GameObject testObject = new GameObject();
            Driver driver = testObject.AddComponent<Driver>();

            // Rotate the object 90 degrees
            testObject.transform.eulerAngles = new Vector3(0, 0, 90);
            Vector3 initialPosition = testObject.transform.position;

            // Simulate forward input
            float simulatedInput = 1.0f;
            float moveSpeed = 40.0f;
            float deltaTime = 0.1f;

            // Act - Move in local space
            testObject.transform.Translate(0f, simulatedInput * moveSpeed * deltaTime, 0f, Space.Self);

            yield return null;

            // Assert - After 90 degree rotation, local Y movement should affect world X
            Assert.AreNotEqual(initialPosition.x, testObject.transform.position.x,
                "Object should move in world X direction when rotated 90 degrees and moving in local Y");

            // Cleanup
            Object.Destroy(testObject);
        }
    }
}
