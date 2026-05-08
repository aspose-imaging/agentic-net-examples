using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.png";
        string canvasTagPath = @"C:\Images\canvas_tag.html";
        string finalHtmlPath = @"C:\Images\output.html";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(canvasTagPath));
        Directory.CreateDirectory(Path.GetDirectoryName(finalHtmlPath));

        try
        {
            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Export only the canvas tag (no full HTML page)
                var options = new Html5CanvasOptions
                {
                    FullHtmlPage = false,
                    VectorRasterizationOptions = new SvgRasterizationOptions()
                };

                image.Save(canvasTagPath, options);
            }

            // Read the generated canvas tag
            string canvasTag = File.ReadAllText(canvasTagPath);

            // Build a full HTML page that embeds the canvas tag
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <meta charset=""UTF-8"">
    <title>Canvas Image</title>
</head>
<body>
    " + canvasTag + @"
</body>
</html>";

            // Write the final HTML page
            File.WriteAllText(finalHtmlPath, htmlContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}