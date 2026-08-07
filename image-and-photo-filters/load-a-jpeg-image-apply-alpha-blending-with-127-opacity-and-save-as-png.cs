using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the JPEG image as a raster image
            using (RasterImage jpegImage = (RasterImage)Image.Load(inputPath))
            {
                // Prepare PNG creation options with a bound file source
                Source fileSource = new FileCreateSource(outputPath, false);
                PngOptions pngOptions = new PngOptions() { Source = fileSource };

                // Create a blank PNG canvas with the same dimensions as the JPEG
                using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, jpegImage.Width, jpegImage.Height))
                {
                    // Blend the JPEG onto the canvas with 127 (≈50%) opacity
                    canvas.Blend(new Point(0, 0), jpegImage, 127);

                    // Save the bound canvas to the output PNG file
                    canvas.Save();
                }
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
 * 1. When a developer needs to overlay a JPEG photograph onto a transparent PNG canvas with 50% opacity to create watermarked thumbnails.
 * 2. When an e‑commerce platform wants to convert product JPEG images into semi‑transparent PNGs for layered UI composition in a C# web application.
 * 3. When a mobile app generates PNG assets with blended JPEG logos to achieve consistent opacity across different screen resolutions using Aspose.Imaging for .NET.
 * 4. When a digital publishing workflow requires converting high‑resolution JPEG scans into PNG files with reduced opacity for use in PDF overlays.
 * 5. When a game developer prepares sprite sheets by loading JPEG textures, applying 127‑level alpha blending, and saving them as PNGs for better alpha channel support.
 */