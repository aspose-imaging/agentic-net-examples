// HOW-TO: Batch Convert JPEG Images to HTML5 Canvas and Combine into One Page in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchJpegToHtml5Canvas
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded paths
                string inputFolder = "input";
                string outputFolder = "output";
                string finalHtmlPath = Path.Combine(outputFolder, "index.html");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(finalHtmlPath));

                // Collect canvas HTML snippets
                List<string> canvasSnippets = new List<string>();

                // Get JPEG files
                string[] jpegFiles = Directory.GetFiles(inputFolder, "*.jpg");

                foreach (string inputPath in jpegFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string canvasFileName = Path.GetFileNameWithoutExtension(inputPath) + ".html";
                    string canvasPath = Path.Combine(outputFolder, canvasFileName);

                    // Ensure directory for canvas file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(canvasPath));

                    // Load JPEG and save as HTML5 Canvas
                    using (Image image = Image.Load(inputPath))
                    {
                        var options = new Html5CanvasOptions();
                        image.Save(canvasPath, options);
                    }

                    // Read generated canvas HTML
                    string canvasHtml = File.ReadAllText(canvasPath);
                    canvasSnippets.Add(canvasHtml);
                }

                // Build final HTML page
                string finalHtml = "<!DOCTYPE html>\n<html>\n<head>\n<title>Canvas Gallery</title>\n</head>\n<body>\n";

                foreach (string snippet in canvasSnippets)
                {
                    finalHtml += snippet + "\n";
                }

                finalHtml += "</body>\n</html>";

                // Write final HTML page
                File.WriteAllText(finalHtmlPath, finalHtml);
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
 * 1. When you need to display a gallery of JPEG photos on a web page without loading external image files, you can convert them to HTML5 canvas snippets and embed them in a single HTML file.
 * 2. When an offline documentation generator must embed images directly into HTML to avoid broken links, this code batch‑processes JPEGs into canvas elements.
 * 3. When a web application requires all images to be rendered via canvas for pixel‑level manipulation or consistent styling, the batch conversion creates ready‑to‑use canvas markup.
 * 4. When you want to archive a collection of JPEG pictures as a self‑contained HTML report that can be opened in any browser, the program produces one HTML page with all canvases.
 * 5. When automating a build pipeline that needs to transform image assets into HTML5 canvas code for email newsletters or static sites, this script handles the bulk conversion and aggregation.
 */
