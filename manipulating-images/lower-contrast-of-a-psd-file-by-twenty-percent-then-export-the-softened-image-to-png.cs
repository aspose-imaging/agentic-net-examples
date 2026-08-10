// HOW-TO: How To Reduce PSD Contrast By 20% And Save As PNG In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.psd";
            string outputPath = "output\\result.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PSD image, adjust contrast, and save as PNG
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                // Lower contrast by 20%
                raster.AdjustContrast(-20f);
                image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to tone down the contrast of a Photoshop PSD before generating a web‑ready PNG thumbnail.
 * 2. When an automated image‑processing pipeline must convert high‑contrast PSD assets into softer PNGs for mobile apps.
 * 3. When a batch job has to prepare print‑ready PSD files with reduced contrast for a specific brand style guide and export them as PNG.
 * 4. When integrating Aspose.Imaging into a C# service that receives PSD uploads, adjusts visual intensity, and returns PNG previews to users.
 * 5. When creating a content‑management workflow that normalizes PSD contrast by 20 % and stores the resulting PNGs for faster CDN delivery.
 */
