using NUnit.Framework;
 class SimpleTester
 {
 [Test]
 public void TestOnePlusOneEqualsTwo()
 {
 // Arrange
 int n1 = 1;
 int n2 = 1;
 int expectedResult = 2;
 // Act
 int result = n1 + n2;
 // Assert
 Assert.AreEqual(expectedResult, result);
 }
 }