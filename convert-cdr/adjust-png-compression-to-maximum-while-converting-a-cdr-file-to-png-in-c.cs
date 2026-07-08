using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.cdr";
        string outputPath = "sample.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    PngCompressionLevel = PngCompressionLevel.ZipLevel9
                };

                if (image is Aspose.Imaging.VectorImage)
                {
                    pngOptions.VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };
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
 * 1. When a developer needs to generate a high‑quality PNG thumbnail of a CorelDRAW (CDR) illustration for a web gallery while minimizing file size, they can use this code to load the CDR, rasterize it, and save with maximum PNG compression.
 * 2. When an e‑commerce platform must convert vendor‑supplied CDR product drawings into compressed PNG images for fast page loads, this snippet automates the conversion and applies ZipLevel9 compression.
 * 3. When a document‑management system requires archiving vector artwork from CDR files as lossless PNGs with the smallest possible footprint, the code loads the vector image, sets PngCompressionLevel to ZipLevel9, and saves the result.
 * 4. When a mobile app needs to display CDR‑based icons as PNG assets without exceeding bandwidth limits, developers can employ this routine to rasterize each page at its original dimensions and compress the PNG to the maximum level.
 * 5. When a batch‑processing tool must convert a folder of CorelDRAW files into PNGs for printing previews while ensuring the output files are as small as possible, this example shows how to programmatically load, rasterize, and save each file with maximum PNG compression in C#.
 */