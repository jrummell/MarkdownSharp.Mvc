using System;
using System.Web.Mvc;
using MarkdownSharp;

namespace CtrlAltDev.MarkdownSharp.Mvc
{
    public static class ControllerExtensions
    {
        /// <summary>
        /// Markdowns the specified content.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="markdown">The markdown.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">controller</exception>
        public static MarkdownResult Markdown(this ControllerBase controller, string markdown, MarkdownOptions options = null)
        {
            if (controller == null)
            {
                throw new ArgumentNullException("controller");
            }

            return new MarkdownResult(markdown, options);
        }
    }
}