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
        string inputPath = @"C:\Images\HighResolutionPhoto.jpg";
        string outputPath = @"C:\Images\CanvasOutput.html";

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
            // Determine scaling factor to fit within 1920x1080 while preserving aspect ratio
            double maxWidth = 1920.0;
            double maxHeight = 1080.0;
            double widthScale = maxWidth / image.Width;
            double heightScale = maxHeight / image.Height;
            double scale = Math.Min(widthScale, heightScale);
            if (scale > 1) scale = 1; // Do not upscale if image is already smaller

            int newWidth = (int)(image.Width * scale);
            int newHeight = (int)(image.Height * scale);

            // Resize the image if needed
            if (newWidth != image.Width || newHeight != image.Height)
            {
                image.Resize(newWidth, newHeight, ResizeType.HighQualityResample);
            }

            // Prepare HTML5 Canvas export options
            var canvasOptions = new Html5CanvasOptions
            {
                FullHtmlPage = true,
                // For raster images the vector rasterization options can be left null,
                // but setting a default instance does not hurt.
                VectorRasterizationOptions = new SvgRasterizationOptions()
            };

            // Save the image as an HTML5 Canvas file
            image.Save(outputPath, canvasOptions);
        }
    }
}