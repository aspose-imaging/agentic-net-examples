// HOW-TO: Apply Gaussian Blur to PSD and Save as PNG with Text Anti-Alias in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.psd";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var raster = image as Aspose.Imaging.RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Failed to load raster image.");
                    return;
                }

                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions();
                blurOptions.Radius = 5;
                blurOptions.Sigma = 1.0;

                raster.Filter(raster.Bounds, blurOptions);

                var graphics = new Aspose.Imaging.Graphics(raster);
                graphics.TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAliasGridFit;

                var pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When you need to soften a Photoshop PSD background before generating a PNG thumbnail for a web gallery.
 * 2. When you want to apply a Gaussian blur to a PSD layer and preserve crisp anti‑aliased text in the exported PNG.
 * 3. When an automated pipeline must convert edited PSD files to PNG while ensuring text is rendered with GridFit smoothing.
 * 4. When you are building a C# service that processes PSD assets, blurs them for privacy, and outputs PNGs for mobile apps.
 * 5. When you require programmatic control over image filters and text rendering hints while converting PSD to PNG using Aspose.Imaging.
 */
