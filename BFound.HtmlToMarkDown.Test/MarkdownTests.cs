using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BFound.HtmlToMarkdown;

namespace BFound.HtmlToMarkDown.Test
{
    [TestClass]
    public class MarkdownTests
    {
        [TestMethod]
        public void TestPlainText()
        {
            Assert.AreEqual("Plain text", MarkDownDocument.FromHtml("Plain text"));
        }

        [TestMethod]
        public void TestBold()
        {
            Assert.AreEqual("**Bold** **Strong**", MarkDownDocument.FromHtml("<b>Bold</b> <strong>Strong</strong>"));
        }

        [TestMethod]
        public void TestItalic()
        {
            Assert.AreEqual("_Italic_ _Empahis_", MarkDownDocument.FromHtml("<i>Italic</i> <em>Empahis</em>"));
        }

        [TestMethod]
        public void TestImage()
        {
            Assert.AreEqual("![Alt Text](proto:path)", MarkDownDocument.FromHtml("<img src=\"proto:path\" alt=\"Alt Text\" />"));
            Assert.AreEqual("![](proto:path)", MarkDownDocument.FromHtml("<img src=\"proto:path\" />"));
            Assert.AreEqual("![Alt Text]()", MarkDownDocument.FromHtml("<img alt=\"Alt Text\" />"));
        }

        [TestMethod]
        public void TestLink()
        {
            Assert.AreEqual("[Link Text](proto:path)", MarkDownDocument.FromHtml("<a href=\"proto:path\">Link Text</a>"));
        }

        [TestMethod]
        public void TestHeading()
        {
            Assert.AreEqual("# Heading Text\r\n\r\n", MarkDownDocument.FromHtml("<h1>Heading Text</h1>"));
            Assert.AreEqual("## Heading Text\r\n\r\n", MarkDownDocument.FromHtml("<h2>Heading Text</h2>"));
            Assert.AreEqual("### Heading Text\r\n\r\n", MarkDownDocument.FromHtml("<h3>Heading Text</h3>"));
            Assert.AreEqual("#### Heading Text\r\n\r\n", MarkDownDocument.FromHtml("<h4>Heading Text</h4>"));
            Assert.AreEqual("##### Heading Text\r\n\r\n", MarkDownDocument.FromHtml("<h5>Heading Text</h5>"));
        }

        [TestMethod]
        public void TestHorizontalRule()
        {
            Assert.AreEqual("\r\n--------\r\n", MarkDownDocument.FromHtml("<hr />"));
        }

        [TestMethod]
        public void TestParagraph()
        {
            Assert.AreEqual("Paragraph Text\r\n\r\n", MarkDownDocument.FromHtml("<p>Paragraph Text</p>"));
        }

        [TestMethod]
        public void TestBreak()
        {
            Assert.AreEqual("Paragraph  \r\nText\r\n\r\n", MarkDownDocument.FromHtml("<p>Paragraph<br/>Text</p>"));
        }

        [TestMethod]
        public void TestSingleBreakIfInDiv()
        {
            Assert.AreEqual("Paragraph Text  \r\n", MarkDownDocument.FromHtml("<div>Paragraph Text</div>"));
            Assert.AreEqual("Paragraph Text  \r\n", MarkDownDocument.FromHtml("<div>Paragraph Text<br/></div>"));
        }

        [TestMethod]
        public void TestBlockQuote()
        {
            Assert.AreEqual("\r\n> Quote Text\r\n", MarkDownDocument.FromHtml("<blockquote>Quote Text</blockquote>"));
        }

        [TestMethod]
        public void TestNestedBlockQuote()
        {
            Assert.AreEqual("\r\n> Quote Text\r\n> > Inner Quote Text\r\n> More Text\r\n", 
                MarkDownDocument.FromHtml("<blockquote>Quote Text<blockquote>Inner Quote Text</blockquote>More Text</blockquote>"));
        }

        [TestMethod]
        public void TestUnorderdList()
        {
            Assert.AreEqual("\r\n  * Item 1\r\n  * Item 2\r\n  * Item 3", MarkDownDocument.FromHtml("<ul><li>Item 1</li><li>Item 2</li><li>Item 3</li></ul>"));
        }

        [TestMethod]
        public void TestOrderdList()
        {
            Assert.AreEqual("\r\n  1. Item 1\r\n  2. Item 2\r\n  3. Item 3", MarkDownDocument.FromHtml("<ol><li>Item 1</li><li>Item 2</li><li>Item 3</li></ol>"));
        }

        [TestMethod]
        public void TestNestedList()
        {
            Assert.AreEqual("\r\n  1. Item 1\r\n       * Item 1\r\n       * Item 2\r\n       * Item 3\r\n  2. Item 2\r\n  3. Item 3", 
                MarkDownDocument.FromHtml("<ol><li>Item 1<ul><li>Item 1</li><li>Item 2</li><li>Item 3</li></ul></li><li>Item 2</li><li>Item 3</li></ol>"));
        }

        [TestMethod]
        public void TestNestedList2()
        {
            Assert.AreEqual("\r\n  * Item 1\r\n      1. Item 1\r\n      2. Item 2\r\n      3. Item 3\r\n  * Item 2\r\n  * Item 3",
                MarkDownDocument.FromHtml("<ul><li>Item 1<ol><li>Item 1</li><li>Item 2</li><li>Item 3</li></ol></li><li>Item 2</li><li>Item 3</li></ul>"));
        }
    }
}
