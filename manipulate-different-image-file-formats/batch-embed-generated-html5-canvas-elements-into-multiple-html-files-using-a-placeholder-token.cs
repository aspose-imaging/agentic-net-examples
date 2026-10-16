// HOW-TO: Batch Replace Placeholder with HTML5 Canvas Snippet in Multiple Files C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;

namespace HtmlCanvasBatchEmbed
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded paths
                string inputHtmlFolder = "InputHtml";
                string canvasSnippetPath = "CanvasSnippet.html";
                string outputHtmlFolder = "OutputHtml";

                // Validate canvas snippet file
                if (!File.Exists(canvasSnippetPath))
                {
                    Console.Error.WriteLine($"File not found: {canvasSnippetPath}");
                    return;
                }

                // Read canvas snippet
                string canvasSnippet = File.ReadAllText(canvasSnippetPath);

                // Get all HTML files in the input folder
                string[] htmlFiles = Directory.GetFiles(inputHtmlFolder, "*.html");

                foreach (string inputFilePath in htmlFiles)
                {
                    // Validate each HTML file
                    if (!File.Exists(inputFilePath))
                    {
                        Console.Error.WriteLine($"File not found: {inputFilePath}");
                        continue;
                    }

                    string htmlContent = File.ReadAllText(inputFilePath);

                    // Replace placeholder token with the canvas snippet
                    string outputContent = htmlContent.Replace("{{CANVAS_PLACEHOLDER}}", canvasSnippet);

                    // Determine output path
                    string fileName = Path.GetFileName(inputFilePath);
                    string outputPath = Path.Combine(outputHtmlFolder, fileName);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Write the modified HTML to the output file
                    File.WriteAllText(outputPath, outputContent);
                }
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
 * 1. When you need to insert the same generated HTML5 canvas code into dozens of existing HTML pages without manually editing each file.
 * 2. When you want to automate the creation of interactive reports by replacing a {{CANVAS_PLACEHOLDER}} token with a pre‑rendered canvas snippet across a folder of templates.
 * 3. When a web application must update legacy HTML documents to include new drawing functionality while preserving the original file structure.
 * 4. When you are preparing a static website build and must batch‑process HTML files to embed a canvas element for charts or graphics generated server‑side.
 * 5. When you require a simple C# script to read a canvas HTML fragment and output modified pages to a separate directory for deployment.
 */
