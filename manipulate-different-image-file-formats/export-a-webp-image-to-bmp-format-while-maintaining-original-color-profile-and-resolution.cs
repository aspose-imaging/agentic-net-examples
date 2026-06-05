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
            string inputPath = "Input\\sample.webp";
            string outputPath = "Output\\sample.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                using (BmpOptions options = new BmpOptions())
                {
                    options.KeepMetadata = true;
                    options.ResolutionSettings = new ResolutionSetting(raster.HorizontalResolution, raster.VerticalResolution);
                    raster.Save(outputPath, options);
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
 * 1. When a developer needs to convert WebP images received from a web service into BMP files for legacy Windows applications while preserving the original color profile and DPI settings.
 * 2. When an e‑learning platform must generate high‑resolution BMP assets from user‑uploaded WebP graphics to ensure compatibility with older presentation software that does not support WebP.
 * 3. When a digital archiving system requires batch conversion of WebP photographs to BMP format, keeping metadata and exact resolution for accurate cataloging and printing.
 * 4. When a game engine that only loads BMP textures needs to import WebP assets created by designers, and the developer wants to maintain the original color fidelity and resolution during the conversion.
 * 5. When a medical imaging workflow needs to transform WebP scans into BMP files for analysis tools that expect uncompressed raster images, while retaining the original color profile and DPI for diagnostic accuracy.
 */