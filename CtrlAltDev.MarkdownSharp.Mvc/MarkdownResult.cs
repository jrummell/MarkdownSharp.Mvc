using System.Web.Mvc;
using MarkdownSharp;

namespace CtrlAltDev.MarkdownSharp.Mvc
{
    /// <summary>
    /// A <see cref="ContentResult" /> implementation that transforms markdown <see cref="ContentResult.Content" /> into html.
    /// </summary>
    public class MarkdownResult : ContentResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarkdownResult" /> class.
        /// </summary>
        public MarkdownResult()
        {
            Options = new MarkdownOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkdownResult" /> class.
        /// </summary>
        /// <param name="markdown">The markdown.</param>
        /// <param name="options">The options.</param>
        public MarkdownResult(string markdown, MarkdownOptions options)
        {
            Content = markdown;
            Options = options;
        }

        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        /// <value>
        /// The options.
        /// </value>
        public MarkdownOptions Options { get; set; }

        #region Overrides of ActionResult

        /// <summary>
        /// Enables processing of the result of an action method by a custom type that inherits from the
        /// <see cref="T:System.Web.Mvc.ActionResult" /> class.
        /// </summary>
        /// <param name="context">
        /// The context in which the result is executed. The context information includes the controller,
        /// HTTP content, request context, and route data.
        /// </param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (Options == null)
            {
                Options = new MarkdownOptions();
            }

            Markdown markdown = new Markdown(Options);

            Content = markdown.Transform(Content);
            ContentType = "text/html";

            base.ExecuteResult(context);
        }

        #endregion
    }
}