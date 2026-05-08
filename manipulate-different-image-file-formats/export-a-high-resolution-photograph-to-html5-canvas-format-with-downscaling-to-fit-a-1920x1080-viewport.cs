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
                // Determine scaling factor to fit within 1920x1080 while preserving aspect ratio
                double maxWidth = 1920.0;
                double maxHeight = 1080.0;
                double widthScale = maxWidth / image.Width;
                double heightScale = maxHeight / image.Height;
                double scale = Math.Min(widthScale, heightScale);

                // If the image is already smaller than the viewport, keep original size
                if (scale > 1.0) scale = 1.0;

                int newWidth = (int)(image.Width * scale);
                int newHeight = (int)(image.Height * scale);

                // Resize the image
                image.Resize(newWidth, newHeight);

                // Prepare HTML5 Canvas export options
                var canvasOptions = new Html5CanvasOptions
                {
                    FullHtmlPage = true // generate a full HTML page
                };

                // Save as HTML5 Canvas
                image.Save(outputPath, canvasOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}