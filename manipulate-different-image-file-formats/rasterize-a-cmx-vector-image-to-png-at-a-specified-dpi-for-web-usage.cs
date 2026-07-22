using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.cmx";
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
            // Load the CMX vector image
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                // Configure rasterization options with desired DPI (e.g., 96 DPI for web)
                var rasterOptions = new CmxRasterizationOptions
                {
                    ResolutionSettings = new ResolutionSetting(96, 96)
                };

                // Set PNG export options and attach rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

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
 * 1. When a web developer needs to display legacy CorelDRAW CMX vector artwork on a website, they can rasterize it to a PNG at 96 DPI for fast loading and cross‑browser compatibility.
 * 2. When an e‑commerce platform must generate product thumbnails from CMX design files, this code converts the vectors into web‑ready PNG images at a specified resolution.
 * 3. When a content management system imports client‑provided CMX logos and must store them as PNGs with consistent DPI for responsive design, the rasterization routine ensures uniform image quality.
 * 4. When an automated build pipeline processes design assets and needs to batch‑convert CMX files to PNG for inclusion in HTML email campaigns, the code provides a reliable C# solution.
 * 5. When a digital asset management tool has to preview CMX drawings in a browser without requiring a vector viewer, rasterizing the file to a PNG at the desired DPI enables instant preview generation.
 */