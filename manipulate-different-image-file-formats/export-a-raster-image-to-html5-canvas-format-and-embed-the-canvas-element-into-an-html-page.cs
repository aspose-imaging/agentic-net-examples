// HOW-TO: Export PNG to HTML5 Canvas and Embed in Web Page Using C# (Aspose.Imaging for .NET)
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
                // Hardcoded input and output paths
                string inputPath = "input.png";
                string canvasOutputPath = "canvas.html";
                string finalHtmlPath = "final.html";

                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directories exist
                Directory.CreateDirectory(Path.GetDirectoryName(canvasOutputPath) ?? string.Empty);
                Directory.CreateDirectory(Path.GetDirectoryName(finalHtmlPath) ?? string.Empty);

                // Load the raster image
                using (Image image = Image.Load(inputPath))
                {
                    // Export to HTML5 Canvas format
                    var canvasOptions = new Html5CanvasOptions();
                    image.Save(canvasOutputPath, canvasOptions);
                }

                // Read the generated canvas HTML snippet
                string canvasHtml = File.ReadAllText(canvasOutputPath);

                // Build a full HTML page embedding the canvas
                string finalHtml = @"<!DOCTYPE html>
<html>
<head>
    <meta charset=""utf-8"" />
    <title>Canvas Embed</title>
</head>
<body>
" + canvasHtml + @"
</body>
</html>";

                // Write the final HTML page
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
 * 1. When you need to display a server‑side PNG image on a web page without sending the raw file, you can convert it to an HTML5 canvas snippet and embed it directly.
 * 2. When building a reporting tool that generates HTML reports with inline graphics, you can export raster images to canvas HTML and include them in the final document.
 * 3. When creating an email template that must contain self‑contained graphics, converting the image to a canvas element ensures the image is rendered without external resources.
 * 4. When developing a single‑page application that loads images dynamically, you can pre‑convert images to canvas HTML to reduce client‑side processing and improve load times.
 * 5. When you want to archive images together with their presentation markup, exporting to an HTML5 canvas file and wrapping it in a full HTML page preserves both the visual data and the layout.
 */
