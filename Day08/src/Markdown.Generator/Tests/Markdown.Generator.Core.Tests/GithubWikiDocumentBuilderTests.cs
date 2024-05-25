using Markdown.Generator.Core.Documents;
using Markdown.Generator.Core.Markdown;
using Moq;

namespace Markdown.Generator.Core.Tests
{
    public class GithubWikiDocumentBuilderTests
    {
        private readonly Mock<IMarkdownGenerator> _mockMarkdownGenerator;
        private readonly GithubWikiDocumentBuilder<IMarkdownGenerator> _githubWikiDocumentBuilder;

        public GithubWikiDocumentBuilderTests()
        {
            _mockMarkdownGenerator = new Mock<IMarkdownGenerator>();
            _githubWikiDocumentBuilder = new GithubWikiDocumentBuilder<IMarkdownGenerator>(_mockMarkdownGenerator.Object);
        }

        [Fact]
        public void Given_GithubWikiDocumentBuilder_When_GenerateCalledWithTypes_Then_LoadIsCalledOnce()
        {
            // Arrange
            var types = Type.EmptyTypes;
            var folder = "folder";
            
            // Act
            _githubWikiDocumentBuilder.Generate(types, folder);
            
            // Assert
            _mockMarkdownGenerator.Verify(m => m.Load(types), Times.Once);
        }

        [Fact]
        public void Given_GithubWikiDocumentBuilder_When_GenerateCalledWithDllPath_Then_LoadIsCalledOnce()
        {
            // Arrange
            var dllPath = "dllPath";
            var namespaceMatch = "namespaceMatch";
            var folder = "folder";
            
            // Act
            _githubWikiDocumentBuilder.Generate(dllPath, namespaceMatch, folder);
            
            // Assert
            _mockMarkdownGenerator.Verify(m => m.Load(dllPath, namespaceMatch), Times.Once);
        }

        [Fact]
        public void Given_GithubWikiDocumentBuilder_When_GenerateCalledWithAssemblies_Then_LoadIsCalledOnce()
        {
            // Arrange
            var assemblies = "assemblies";
            var namespaceMatch = "namespaceMatch";
            var folder = "folder";
            
            // Act
            _githubWikiDocumentBuilder.Generate(assemblies, namespaceMatch, folder);
            
            // Assert
            _mockMarkdownGenerator.Verify(m => m.Load(assemblies, namespaceMatch), Times.Once);
        }
    }
}