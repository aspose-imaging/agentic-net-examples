// HOW-TO: Remove Background from CorelDRAW CDR and Save as Transparent PNG in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output\\result.png";

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
 * 1. When you need to extract foreground objects from a CorelDRAW CDR file that shares the same color as the original background and output them as a transparent PNG for web use.
 * 2. When automating a workflow that converts vector CDR designs into PNG assets with an alpha channel for inclusion in UI mockups.
 * 3. When preparing product catalog images by removing the background from CDR logos that have no distinct color separation.
 * 4. When integrating Aspose.Imaging into a C# application to batch‑process CDR files and generate transparent PNG thumbnails for a digital asset management system.
 * 5. When creating printable stickers or decals where the design originates in CDR and must be saved as a PNG with no background to avoid unwanted color bleed.
 */
