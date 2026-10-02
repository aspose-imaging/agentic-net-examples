// HOW-TO: How To Deskew A TIFF And Save As PNG With Transparency Check In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = "input.tif";
        string outputPath = "output.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load image as RasterImage
            using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
            {
                // Deskew the image
                rasterImage.NormalizeAngle();

                // Verify transparency
                bool hasTransparency = false;

                // Prefer built‑in property if available
                var hasAlphaProp = rasterImage.GetType().GetProperty("HasAlpha");
                if (hasAlphaProp != null && hasAlphaProp.PropertyType == typeof(bool))
                {
                    hasTransparency = (bool)hasAlphaProp.GetValue(rasterImage);
                }
                else
                {
                    // Fallback: scan pixels for any alpha < 255
                    for (int y = 0; y < rasterImage.Height && !hasTransparency; y++)
                    {
                        for (int x = 0; x < rasterImage.Width && !hasTransparency; x++)
                        {
                            var color = rasterImage.GetPixel(x, y);
                            if (color.A < 255)
                                hasTransparency = true;
                        }
                    }
                }

                Console.WriteLine($"Transparency detected: {hasTransparency}");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save as PNG with alpha support
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };
                rasterImage.Save(outputPath, pngOptions);
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
 * 1. When you need to correct the rotation of scanned TIFF documents before converting them to web‑friendly PNGs.
 * 2. When you must ensure that a TIFF image contains an alpha channel before exporting it as a PNG for overlay purposes.
 * 3. When processing batch scans where each file may be slightly skewed and you need an automated C# routine to normalize orientation and preserve transparency.
 * 4. When integrating Aspose.Imaging into a document‑management system that stores original TIFFs but serves PNG thumbnails with correct alignment.
 * 5. When building a C# utility that validates whether a source image has any transparent pixels before deciding how to handle PNG compression.
 */
