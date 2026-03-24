using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string baseImagePath = @"C:\temp\base.png";
        string[] overlayPaths = new string[]
        {
            @"C:\temp\overlay1.png",
            @"C:\temp\overlay2.png"
        };
        string outputPath = @"C:\temp\output.png";

        // Verify base image exists
        if (!File.Exists(baseImagePath))
        {
            Console.Error.WriteLine($"File not found: {baseImagePath}");
            return;
        }

        // Verify each overlay image exists
        foreach (string overlayPath in overlayPaths)
        {
            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"File not found: {overlayPath}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the base image
        using (Aspose.Imaging.RasterImage baseImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(baseImagePath))
        {
            // Create a Graphics instance for drawing
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(baseImage);

            // Draw each overlay onto the base image
            int offsetX = 0;
            foreach (string overlayPath in overlayPaths)
            {
                using (Aspose.Imaging.RasterImage overlay = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(overlayPath))
                {
                    graphics.DrawImage(overlay, offsetX, 0);
                    offsetX += overlay.Width;
                }
            }

            // Save the resulting image as PNG
            PngOptions pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };
            baseImage.Save(outputPath, pngOptions);
        }
    }
}