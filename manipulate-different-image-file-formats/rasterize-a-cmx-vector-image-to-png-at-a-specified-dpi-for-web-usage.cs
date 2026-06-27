using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.cmx";
            string outputPath = "Output/sample.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CMX vector image
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                // Configure PNG save options
                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                // Set rasterization options for CMX
                var rasterOptions = new CmxRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    ResolutionSettings = new ResolutionSetting(96, 96) // DPI for web usage
                };

                pngOptions.VectorRasterizationOptions = rasterOptions;

                // Save rasterized PNG
                cmx.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to display legacy CorelDRAW CMX artwork on a modern website, they can rasterize the vector file to a PNG at 96 DPI to ensure fast loading and consistent colors.
 * 2. When an e‑commerce platform must generate product thumbnails from CMX source files, the code converts the vector to a web‑optimized PNG with a white background and fixed resolution.
 * 3. When a content management system imports user‑uploaded CMX diagrams and must store them as PNG images for browser compatibility, the rasterization at a specific DPI guarantees uniform sizing across devices.
 * 4. When a reporting tool creates PDF dashboards that embed CMX charts, it first rasterizes the vectors to PNG at 96 DPI so the images render correctly in HTML preview mode.
 * 5. When a mobile app needs to cache CMX icons as PNG assets for offline use, the code rasterizes the vectors at a web‑friendly DPI, preserving text rendering hints and eliminating vector support dependencies.
 */