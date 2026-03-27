using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\HighResPhoto.jpg";
        string outputPath = @"C:\Images\output\Canvas.html";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the high‑resolution image
        using (Image image = Image.Load(inputPath))
        {
            // Desired viewport size
            const int maxWidth = 1920;
            const int maxHeight = 1080;

            // Compute scaling factor while preserving aspect ratio
            double widthScale = (double)maxWidth / image.Width;
            double heightScale = (double)maxHeight / image.Height;
            double scale = Math.Min(widthScale, heightScale);
            if (scale > 1) scale = 1; // Do not upscale if image is smaller than viewport

            int newWidth = (int)(image.Width * scale);
            int newHeight = (int)(image.Height * scale);

            // Downscale the image
            image.Resize(newWidth, newHeight);

            // Prepare HTML5 Canvas export options
            var canvasOptions = new Html5CanvasOptions
            {
                FullHtmlPage = true,                     // Generate a full HTML page
                CanvasTagId = "myCanvas",                // Optional canvas tag identifier
                VectorRasterizationOptions = null        // Use default rasterization for raster images
            };

            // Save as HTML5 Canvas
            image.Save(outputPath, canvasOptions);
        }
    }
}