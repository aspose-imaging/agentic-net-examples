// HOW-TO: Remove Background from EMF and Save as Transparent PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                VectorImage vectorImage = image as VectorImage;
                if (vectorImage != null)
                {
                    var removeSettings = new RemoveBackgroundSettings();
                    vectorImage.RemoveBackground(removeSettings);
                }

                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageSize = image.Size
                    }
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
 * 1. When you need to convert legacy EMF vector graphics to PNG with a transparent background for web display.
 * 2. When you want to eliminate unwanted colored regions in an EMF file before embedding it in a PDF report.
 * 3. When preparing icons from EMF files for mobile apps that require alpha channel support.
 * 4. When automating batch processing of EMF drawings to generate clean PNG assets for UI design.
 * 5. When integrating Aspose.Imaging into a C# service that strips backgrounds from vector images for e‑commerce product catalogs.
 */
