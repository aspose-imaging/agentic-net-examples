// HOW-TO: Resize CorelDRAW CDR to 1024x768 PNG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.cdr";
        string outputPath = "Output/resized.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = 1024,
                        PageHeight = 768
                    }
                };

                cdr.Save(outputPath, pngOptions);
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
 * 1. When you need to generate web‑ready thumbnails from CorelDRAW designs by converting them to PNG at a specific resolution.
 * 2. When an automated batch process must convert legacy CDR files into raster images for inclusion in a PDF report.
 * 3. When a desktop application requires on‑the‑fly resizing of vector drawings to fit a fixed UI layout.
 * 4. When a cloud service ingests CDR artwork and needs to store a standardized 1024×768 PNG for preview thumbnails.
 * 5. When migrating a design archive to a format supported by browsers, you must rasterize each CDR to a white‑background PNG of exact dimensions.
 */
