using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input/HighResPhoto.jpg";
            string outputPath = "output/PhotoCanvas.html";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the high‑resolution photograph
            using (Image image = Image.Load(inputPath))
            {
                // Determine scaling factor to fit within 1920x1080 while preserving aspect ratio
                const double maxWidth = 1920.0;
                const double maxHeight = 1080.0;
                double widthRatio = maxWidth / image.Width;
                double heightRatio = maxHeight / image.Height;
                double scale = Math.Min(widthRatio, heightRatio);

                // Downscale only if the image is larger than the viewport
                if (scale < 1.0)
                {
                    int newWidth = (int)(image.Width * scale);
                    int newHeight = (int)(image.Height * scale);
                    image.Resize(newWidth, newHeight);
                }

                // Prepare HTML5 Canvas export options
                var options = new Html5CanvasOptions
                {
                    FullHtmlPage = true
                };

                // Save as HTML5 Canvas file
                image.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web developer needs to embed a high‑resolution photograph in an HTML5 Canvas page that automatically fits a 1920 × 1080 viewport, this C# code resizes the image and saves it as a full‑HTML canvas file using Aspose.Imaging.
 * 2. When an e‑learning platform wants to display large classroom photos on student devices without scrolling, the code downscales the JPEG and exports it to HTML5 Canvas for responsive rendering.
 * 3. When a digital marketing team creates interactive product galleries and must ensure each high‑resolution image loads quickly on standard monitors, they can use this snippet to generate canvas‑based HTML that respects the 1920 × 1080 size limit.
 * 4. When a desktop application converts archival photos into web‑ready assets, the code leverages Aspose.Imaging’s Html5CanvasOptions to produce a self‑contained HTML page that fits typical screen resolutions.
 * 5. When a SaaS reporting tool needs to embed detailed charts as images inside a canvas element while preserving aspect ratio on a 1080p dashboard, this C# example provides the necessary resize‑and‑export workflow.
 */