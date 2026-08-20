// HOW-TO: Rasterize CMX Vector to PNG at Specific DPI in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.cmx";
            string outputPath = "output/output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX vector image
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                // Prepare PNG save options with rasterization settings
                PngOptions pngOptions = new PngOptions();

                // Configure rasterization options (e.g., DPI for web usage)
                CmxRasterizationOptions rasterOptions = new CmxRasterizationOptions
                {
                    // Set desired resolution (e.g., 96 DPI)
                    ResolutionSettings = new ResolutionSetting(96, 96),

                    // Optional: set background color to white
                    BackgroundColor = Color.White,

                    // Optional: define positioning
                    Positioning = PositioningTypes.DefinedByDocument
                };

                pngOptions.VectorRasterizationOptions = rasterOptions;

                // Save the rasterized image as PNG
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
 * 1. When you need to display legacy CorelDRAW CMX artwork on a website, you can rasterize it to a PNG at web‑friendly DPI using C#.
 * 2. When a web application must generate thumbnails from CMX files on the fly, this code converts the vector to a PNG with the required resolution.
 * 3. When migrating a design archive, you can batch‑process CMX drawings into PNGs for browsers that only support raster images.
 * 4. When creating printable previews that require a fixed DPI, the snippet renders the CMX vector into a PNG with exact pixel density.
 * 5. When integrating Aspose.Imaging into a .NET service that receives CMX uploads, you can instantly rasterize and store them as PNGs for downstream processing.
 */
