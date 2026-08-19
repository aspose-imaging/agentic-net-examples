// HOW-TO: Convert CDR to PNG with Alpha Channel Preservation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.cdr";
        string outputPath = "Output/sample.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PngOptions pngOptions = new PngOptions())
                {
                    pngOptions.ColorType = PngColorType.TruecolorWithAlpha;

                    if (image is VectorImage)
                    {
                        pngOptions.VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        };
                    }

                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to export CorelDRAW (CDR) artwork to web‑ready PNG files while keeping transparent backgrounds intact.
 * 2. When a graphics pipeline requires rasterizing vector CDR pages to PNG with truecolor and alpha for further image processing.
 * 3. When generating thumbnails of CDR designs for a mobile app and the thumbnails must retain original transparency.
 * 4. When automating batch conversion of CDR assets to PNG for a design system that relies on PNG’s alpha channel for layering.
 * 5. When integrating CorelDRAW files into a .NET application that displays PNG images with transparent regions in a UI.
 */
