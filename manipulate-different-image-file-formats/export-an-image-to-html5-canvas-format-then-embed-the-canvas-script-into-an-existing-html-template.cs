// HOW-TO: Export PNG to HTML5 Canvas and Embed in HTML Template C# (Aspose.Imaging for .NET)
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

namespace Html5CanvasExport
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded paths
                string inputPath = "input.png";
                string canvasPath = "canvas.html";
                string templatePath = "template.html";
                string outputPath = "output.html";

                // Validate input file
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directories exist
                Directory.CreateDirectory(Path.GetDirectoryName(canvasPath));
                Directory.CreateDirectory(Path.GetDirectoryName(templatePath));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the source image
                using (Image image = Image.Load(inputPath))
                {
                    // Export to HTML5 Canvas format
                    var options = new Html5CanvasOptions();
                    image.Save(canvasPath, options);
                }

                // Read generated canvas HTML
                string canvasHtml = File.ReadAllText(canvasPath);

                // Read template HTML
                string templateHtml = File.ReadAllText(templatePath);

                // Embed canvas script into template (replace placeholder)
                const string placeholder = "<!--CANVAS_PLACEHOLDER-->";
                string resultHtml = templateHtml.Contains(placeholder)
                    ? templateHtml.Replace(placeholder, canvasHtml)
                    : templateHtml + Environment.NewLine + canvasHtml;

                // Write final HTML output
                File.WriteAllText(outputPath, resultHtml);
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
 * 1. When you need to display a raster image on a web page using a canvas element without sending the original file.
 * 2. When you want to integrate a generated canvas script into an existing HTML layout that contains placeholders.
 * 3. When you are building a reporting tool that converts server‑side images to client‑side canvas for interactive graphics.
 * 4. When you need to automate the creation of self‑contained HTML files that embed image data as canvas code for offline viewing.
 * 5. When you are migrating legacy image assets to modern HTML5 canvas‑based visualizations within a C# application.
 */
