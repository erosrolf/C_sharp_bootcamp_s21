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
    public void Given_Header_When_LevelAndHeaderAsParam_Then_ReturnMDHeaderMarkup()
    {
        // Arrange
        string expected = "## header\n";

        // Act
        Header headerElement = new Header(2, "header");
        string actual = headerElement.Create();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Given_List_When_TextAsParam_Then_ReturnMDListMarkup()
    {
        // Arrange
        string expected = "- list\n";
        
        // Act
        Markdown.Elements.List listElement = new List("list");
        string actual = listElement.Create();
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Given_Link_When_TitleAndUrlAsParam_Then_ReturnMDLinkMarkup()
    {
        // Arrange
        string expected = "[Google](https://www.google.com/)";

        // Act
        Link linkElement = new Link("Google", "https://www.google.com/");
        string actual = linkElement.Create();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Given_Image_When_TitleAndUrlAsParame_Then_ReturnMDImageMarkup()
    {
        // Arrange
        string expected =
            "![GoogleLogo](https://www.google.com/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png)";
        
        // Act
        Image imageElement = new Image("GoogleLogo",
            "https://www.google.com/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png");
        string actual = imageElement.Create();
        
        // Assert
        Assert.Equal(expected, actual);
    }
}