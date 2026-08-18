// HOW-TO: Export PNG to HTML5 Canvas and Embed in HTML with C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\Images\sample.png";
        string canvasPath = @"C:\Output\canvas.html";
        string finalHtmlPath = @"C:\Output\final.html";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(canvasPath));
            Directory.CreateDirectory(Path.GetDirectoryName(finalHtmlPath));

            // Load raster image and export only the canvas tag
            using (var image = Image.Load(inputPath))
            {
                var options = new Html5CanvasOptions
                {
                    FullHtmlPage = false // generate only the <canvas> element
                };
                image.Save(canvasPath, options);
            }

            // Read the generated canvas tag
            string canvasTag = File.ReadAllText(canvasPath);

            // Build a full HTML page that embeds the canvas
            string finalHtml = @"<!DOCTYPE html>
<html>
<head>
    <meta charset=""UTF-8"">
    <title>Canvas Embed</title>
</head>
<body>
" + canvasTag + @"
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

/*
 * Real-World Use Cases:
 * 1. When you need to convert a server‑side PNG file into a lightweight <canvas> element for inclusion in a web page without loading the full image file.
 * 2. When generating dynamic HTML reports that display raster graphics using HTML5 Canvas to ensure consistent rendering across browsers.
 * 3. When building an image preview feature in a C# web application that embeds the picture directly into the page via a canvas tag instead of an <img> element.
 * 4. When creating automated documentation that requires embedding raster images as canvas elements to reduce page size and improve load times.
 * 5. When migrating legacy image assets to modern HTML5 Canvas format using Aspose.Imaging for .NET to simplify client‑side drawing operations.
 */
