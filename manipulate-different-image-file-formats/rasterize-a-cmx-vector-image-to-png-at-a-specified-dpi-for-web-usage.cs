using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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

            // Configure PNG save options with CMX rasterization settings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new CmxRasterizationOptions
                {
                    // Set desired DPI for web usage
                    ResolutionSettings = new Aspose.Imaging.ResolutionSetting(96, 96)
                }
            };

            // Load the CMX image and save as PNG using the configured options
            using (Image cmxImage = Image.Load(inputPath))
            {
                cmxImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert legacy Corel Metafile (CMX) vector graphics into web‑friendly PNG images at 96 DPI for faster page loads.
 * 2. When an e‑commerce site must display product diagrams originally stored as CMX files, and the images must be rasterized to PNG with a specific resolution for consistent thumbnail sizing.
 * 3. When a content management system imports archival CMX artwork and requires automated C# code to generate PNG previews at a standard web DPI.
 * 4. When a reporting tool generates charts in CMX format and the final PDF or HTML report needs those charts rasterized to PNG at 96 DPI for cross‑browser compatibility.
 * 5. When a mobile app backend processes user‑uploaded CMX files and must deliver PNG assets optimized for web display at a fixed DPI without manual intervention.
 */