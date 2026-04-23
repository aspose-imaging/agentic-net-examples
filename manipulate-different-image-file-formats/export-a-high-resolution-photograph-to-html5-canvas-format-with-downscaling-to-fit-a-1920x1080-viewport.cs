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
            string inputPath = @"C:\Images\HighResPhoto.jpg";
            string outputPath = @"C:\Images\ExportedCanvas.html";

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
                // Calculate scaling factor to fit within 1920x1080 while preserving aspect ratio
                double widthScale = 1920.0 / image.Width;
                double heightScale = 1080.0 / image.Height;
                double scale = Math.Min(widthScale, heightScale);
                if (scale < 1.0) // Downscale only if larger than viewport
                {
                    int newWidth = (int)(image.Width * scale);
                    int newHeight = (int)(image.Height * scale);
                    image.Resize(newWidth, newHeight);
                }

                // Prepare HTML5 Canvas export options
                var canvasOptions = new Html5CanvasOptions
                {
                    FullHtmlPage = true // generate a full HTML page
                };

                // Save the image as HTML5 Canvas
                image.Save(outputPath, canvasOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}