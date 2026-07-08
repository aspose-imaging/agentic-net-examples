using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"input.cdr";
        string outputPath = @"output\converted.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdrImage = (CdrImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 24,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = cdrImage.Width,
                        PageHeight = cdrImage.Height,
                        BackgroundColor = Aspose.Imaging.Color.White
                    }
                };

                cdrImage.Save(outputPath, bmpOptions);
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
 * 1. When a designer needs to batch‑convert legacy CorelDRAW (.cdr) artwork into 24‑bit BMP files for printing workflows that require uncompressed raster images.
 * 2. When an automated build pipeline must generate Windows‑compatible bitmap thumbnails from CDR source files for inclusion in a documentation portal.
 * 3. When a legacy desktop application only supports BMP input, a developer can use this code to rasterize vector CDR graphics at their original dimensions with a white background.
 * 4. When a content management system stores vector assets in CorelDRAW format but needs to serve them as BMP images to devices that lack vector rendering capabilities.
 * 5. When a migration script has to preserve the exact color depth of original designs while converting CDR files to BMP for archival storage in a .NET environment.
 */