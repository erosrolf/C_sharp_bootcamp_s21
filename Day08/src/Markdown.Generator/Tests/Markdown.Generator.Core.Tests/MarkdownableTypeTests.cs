using Markdown.Generator.Core.Markdown;

namespace Markdown.Generator.Core.Tests
{
    public class Sut
    {
        public void PublicMethod() {}
        private void PrivateMethod() {}

        public string PublicField;
        private string PrivateField;
        
        public string PublicProperty { get; }
        private string PrivateProperty { get; }
    }
    
    public class MarkdownableTypeTests
    {
        [Fact]
        public void Given_MarkdownableType_When_GetMethodsCalled_Then_ReturnsOnlyPublicMethods()
        {
            // Arrange
            var markdownableType = new MarkdownableType(typeof(Sut), null);
            
            // Act
            var methods = markdownableType.GetMethods();
            
            // Assert
            Assert.Single(methods);
            Assert.Equal("PublicMethod", methods.First().Name);
            Assert.True(methods.First().IsPublic);
        }

        [Fact]
        public void Given_MarkdownableType_When_GetFieldsCalled_Then_ReturnsOnlyPublicFields()
        {
            // Arrange
            var markdownableType = new MarkdownableType(typeof(Sut), null);
            
            // Act
            var fields = markdownableType.GetFields();
            
            // Assert
            Assert.Single(fields);
            Assert.Equal("PublicField", fields.First().Name);
            Assert.True(fields.First().IsPublic);
        }

        [Fact]
        public void Given_MarkdownableType_When_GetPropertyCalled_Then_ReturnsOnlyPublicProperties()
        {
            // Arrange
            var markdownableType = new MarkdownableType(typeof(Sut), null);
            
            // Act
            var properties = markdownableType.GetProperties();
            
            // Assert
            Assert.Single(properties);
            Assert.Equal("PublicProperty", properties.First().Name);
        }
    }
}
