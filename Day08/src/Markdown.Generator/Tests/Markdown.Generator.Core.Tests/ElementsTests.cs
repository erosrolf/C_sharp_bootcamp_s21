using Markdown.Generator.Core.Markdown.Elements;

namespace Markdown.Generator.Core.Tests;

public class ElementsTests
{
    [Fact]
    public void Given_Code_When_LanguageAndCodeAsParam_Then_ReturnMDCodeMarkup()
    {
        // Arrange
        string expected = "```csharp\nsome code\n```\n";
        
        // Act
        Code codeElement = new Code("csharp", "some code");
        string actual = codeElement.Create();
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Given_CodeQuote_When_QuoteAsParam_Then_ReturnMDCodeQuoteMarkup()
    {
        // Arrange
        string expected = "`code`";
        
        // Act
        CodeQuote codeQuoteElement = new CodeQuote("code");
        string actual = codeQuoteElement.Create();
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Given_Link_When_LinkAsParam_Then_ReturnMDLinkMarkup()
    {
        // Arrange
        string expected = "## header\n";

        // Act
        Header headerElement = new Header(2, "header");
        string actual = headerElement.Create();

        //Assert
        Assert.Equal(expected, actual);
    }
}