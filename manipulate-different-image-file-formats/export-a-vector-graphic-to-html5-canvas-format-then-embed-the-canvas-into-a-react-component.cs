// HOW-TO: Convert SVG to HTML5 Canvas and Generate React Component in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string htmlOutputPath = "output.html";
            string reactComponentPath = "CanvasComponent.jsx";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string htmlDir = Path.GetDirectoryName(htmlOutputPath) ?? ".";
            Directory.CreateDirectory(htmlDir);

            using (Image image = Image.Load(inputPath))
            {
                Html5CanvasOptions options = new Html5CanvasOptions();
                image.Save(htmlOutputPath, options);
            }

            string htmlContent = File.ReadAllText(htmlOutputPath);
            string escapedHtml = htmlContent
                .Replace("\\", "\\\\")
                .Replace("`", "\\`")
                .Replace("{", "{{")
                .Replace("}", "}}");

            string componentCode = "import React from 'react';\n\n" +
                                   "const CanvasComponent = () => (\n" +
                                   "  <div dangerouslySetInnerHTML={{ __html: `" + escapedHtml + "` }} />\n" +
                                   ");\n\n" +
                                   "export default CanvasComponent;";

            string componentDir = Path.GetDirectoryName(reactComponentPath) ?? ".";
            Directory.CreateDirectory(componentDir);
            File.WriteAllText(reactComponentPath, componentCode);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display a scalable vector graphic on a web page using an HTML5 canvas inside a React application, this code converts the SVG to canvas markup and creates a ready‑to‑use React component.
 * 2. When a design team provides logos or icons in SVG format and the front‑end team works with React, you can automate the conversion to canvas and embed it without manually rewriting the markup.
 * 3. When building a cross‑platform .NET service that prepares interactive graphics for a React front‑end, the code lets you generate the HTML5 canvas HTML and package it as a JSX component in one step.
 * 4. When you want to avoid loading external SVG files at runtime for performance or security reasons, you can pre‑render the SVG to a canvas string and embed it directly in the React component’s dangerouslySetInnerHTML.
 * 5. When integrating Aspose.Imaging into a CI/CD pipeline to produce static React components from vector assets, this script automates the export, escaping, and file creation process.
 */
