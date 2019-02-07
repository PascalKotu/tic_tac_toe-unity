using NUnit.Framework;

[TestFixture]
public sealed class ExampleTest {
  private Example subject;

  [SetUp]
  public void SetUp() {
    subject = new Example();
  }

  [Test]
  public void FooIsBar() {
    Assert.AreEqual("bar", subject.Foo());
  }
}
