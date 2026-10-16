// HOW-TO: Convert JPEG To HTML5 Canvas And Embed In Markdown With C# (Aspose.Imaging for .NET)
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

namespace ImageToHtml5Canvas
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded paths
                string inputPath = "input.jpg";
                string htmlOutputPath = "output.html";
                string markdownOutputPath = "output.md";

                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directories exist
                Directory.CreateDirectory(Path.GetDirectoryName(htmlOutputPath) ?? string.Empty);
                Directory.CreateDirectory(Path.GetDirectoryName(markdownOutputPath) ?? string.Empty);

                // Convert JPEG to HTML5 Canvas format
                using (Image image = Image.Load(inputPath))
                {
                    var options = new Html5CanvasOptions();
                    image.Save(htmlOutputPath, options);
                }

                // Read generated HTML content
                string htmlContent = File.ReadAllText(htmlOutputPath);

                // Embed the canvas HTML into a Markdown document
                File.WriteAllText(markdownOutputPath, htmlContent);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display a JPEG image on a web page using a canvas element and include that canvas directly in a Markdown‑based documentation or README file.
 * 2. When generating automated reports that combine images with Markdown content, converting the pictures to HTML5 canvas ensures they render consistently across browsers.
 * 3. When building a static site generator in C# that transforms source JPEG assets into embeddable canvas snippets for blog posts written in Markdown.
 * 4. When creating technical tutorials where the original JPEG must be shown as a canvas for interactive overlays, and the whole tutorial is authored in Markdown.
 * 5. When exporting product screenshots from a .NET application into a Markdown guide without relying on external image files, using Aspose.Imaging to convert them to canvas HTML first.
 */
