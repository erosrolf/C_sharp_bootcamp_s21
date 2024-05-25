using System.Linq;
using Markdown.Generator.Core.Markdown;
using Markdown.Generator.Core.Markdown.Elements;

namespace Markdown.Generator.Core.Tests
{
    public class MarkdownBuilderTests_cd
    {
        [Fact]
        public void Given_MarkdownBuilder_When_CodeQuoteCalled_Then_CodeQuoteAddedToElements()
        {
            // Arrange
            var builder = new MarkdownBuilder();
            
            // Act
            builder.CodeQuote("code");
            
            // Assert
            Assert.Single(builder.Elements);
            Assert.IsType<CodeQuote>(builder.Elements.First());
        }

        [Fact]
        public void Given_MarkdownBuilder_When_CodeCalled_Then_CodeAddedToElements()
        {
            // Arrange
            var builder = new MarkdownBuilder();
            
            // Act
            builder.Code("csharp", "some code");
            
            // Assert
            Assert.Single(builder.Elements);
            Assert.IsType<Code>(builder.Elements.First());
        }

        [Fact]
        public void Given_MarkdownBuilder_When_LinkCalled_Then_LinkAddedToElements()
        {
            // Arrange
            var builder = new MarkdownBuilder();
            
            // Act
            builder.Link("Google", "https://www.google.com/");
            
            // Assert
            Assert.Single(builder.Elements);
            Assert.IsType<Link>(builder.Elements.First());
        }

        [Fact]
        public void Given_MarkdownBuilder_When_HeaderCalled_Then_HeaderAddedToElements()
        {
            // Arrange
            var builder = new MarkdownBuilder();
            
            // Act
            builder.Header(2, "header");
            
            // Assert
            Assert.Single(builder.Elements);
            Assert.IsType<Header>(builder.Elements.First());
        }
    }
}
