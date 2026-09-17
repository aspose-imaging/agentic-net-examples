// HOW-TO: Load Multi-Page TIFF and Save with Default Options in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output/output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                TiffOptions options = new TiffOptions(TiffExpectedFormat.Default);
                tiffImage.Save(outputPath, options);
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
 * 1. When you need to read a multi‑page TIFF file and re‑save it unchanged to a different folder using Aspose.Imaging in a .NET application.
 * 2. When you want to verify that a TIFF file exists before processing it to prevent runtime errors in C#.
 * 3. When you must automatically create the output directory while handling multi‑page TIFF images.
 * 4. When building a batch conversion tool that loads TIFF images and saves them with default TiffOptions using Aspose.Imaging.
 * 5. When you require robust error handling to catch and log exceptions during TIFF loading and saving in a C# service.
 */
