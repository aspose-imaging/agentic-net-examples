// HOW-TO: Remove Background From Specific Area Of CDR And Convert To PNG In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.cdr";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageSize = image.Size
                    }
                };

                var vectorImage = image as VectorImage;
                if (vectorImage != null)
                {
                    vectorImage.RemoveBackground(new RemoveBackgroundSettings());
                }

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
 * 1. When you need to extract a logo from a CorelDRAW (CDR) file and save it as a transparent PNG for web display.
 * 2. When you want to create product thumbnails by removing the background of a defined rectangular region in a CDR illustration before rasterizing to PNG.
 * 3. When an e‑commerce site requires clean PNG images of vector artwork with only the foreground retained for overlay on different backgrounds.
 * 4. When automating batch conversion of multiple CDR files to PNG while discarding unwanted background portions within a specific area.
 * 5. When preparing print‑ready assets that need a transparent background only around a selected part of a vector design.
 */
