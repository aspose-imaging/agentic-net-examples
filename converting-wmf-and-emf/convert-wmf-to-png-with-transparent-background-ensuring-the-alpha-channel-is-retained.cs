// HOW-TO: Convert WMF to PNG with Transparent Background and Alpha Channel in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.wmf";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = Color.Transparent,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = rasterOptions
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When you need to embed vector WMF icons into a web page that requires PNG images with transparency.
 * 2. When converting legacy WMF diagrams to PNG for use in mobile apps that support alpha channels.
 * 3. When generating transparent PNG assets from WMF files for PDF reports that overlay graphics.
 * 4. When automating batch processing of WMF logos to PNG format while preserving transparent backgrounds in a C# build pipeline.
 * 5. When preparing WMF illustrations for email newsletters that require PNG images with proper alpha blending.
 */
