using System.Web;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;

namespace CtrlAltDev.MarkdownSharp.Mvc.Tests
{
    [TestFixture]
    public class MarkdownResultFixture
    {
        [Test]
        public void ExecuteResult()
        {
            MarkdownResult result = new MarkdownResult();
            result.Content = "[test](http://example.com)";

            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.SetupGet(c => c.Response).Returns(Mock.Of<HttpResponseBase>());

            var context = new ControllerContext
                          {
                              Controller = Mock.Of<ControllerBase>(),
                              HttpContext = mockHttpContext.Object
                          };

            result.ExecuteResult(context);

            Assert.That(result.Content, Is.EqualTo("<p><a href=\"http://example.com\">test</a></p>\n"));
        }
    }
}