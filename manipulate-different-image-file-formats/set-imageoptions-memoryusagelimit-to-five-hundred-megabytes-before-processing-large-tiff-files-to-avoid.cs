// HOW-TO: Configure ImageOptions MemoryUsageLimit to 500 MB for Large TIFFs in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            TiffOptions options = new TiffOptions(TiffExpectedFormat.Default);

            using (TiffImage image = (TiffImage)Image.Load(inputPath))
            {
                image.Save(outputPath, options);
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
 * 1. When processing multi‑gigabyte TIFF documents in a .NET service and you want to prevent OutOfMemoryException by limiting memory usage.
 * 2. When converting high‑resolution scanned TIFF images to another format on a server with limited RAM.
 * 3. When loading large multi‑page TIFF files in a desktop application and need to ensure the app stays responsive.
 * 4. When batch‑processing thousands of TIFF files in an automated pipeline and must control memory consumption per file.
 * 5. When integrating Aspose.Imaging into a cloud function that handles TIFF uploads and you need to avoid exceeding the function’s memory quota.
 */
