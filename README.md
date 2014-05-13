HtmlToMarkDown
==============

A HTML to Markdown converter in C#

Usage
=====

    var html = System.IO.File.ReadAllText("Index.html");
    var markdown = MarkDownDocument.FromHtml(html);
    Console.WriteLine(markdown);
    
