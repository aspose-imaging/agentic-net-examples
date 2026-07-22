using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tga;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\background.tga";
            string outputPath = @"C:\Images\background_converted.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TGA image
            using (RasterImage tgaImage = (RasterImage)Image.Load(inputPath))
            {
                // Save as lossless PNG while preserving metadata (including color profile)
                var pngOptions = new PngOptions
                {
                    // KeepMetadata preserves color profile and other metadata
                    KeepMetadata = true
                };

                tgaImage.Save(outputPath, pngOptions);
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
 * 1. When a game developer needs to convert legacy TGA background textures to lossless PNG files for modern engines while preserving the original color profile.
 * 2. When a UI designer wants to replace high‑resolution TGA assets with PNGs for web deployment without losing color accuracy or embedded metadata.
 * 3. When an automated build script must batch‑process TGA images into PNGs in a .NET application, ensuring the output remains lossless and retains ICC profiles.
 * 4. When a digital archivist needs to migrate TGA files to a more widely supported PNG format while keeping all metadata intact for future retrieval.
 * 5. When a C# service integrates Aspose.Imaging to read TGA files and store them as PNGs with preserved color information for downstream image‑processing pipelines.
 */