// HOW-TO: Set ImageOptions MemoryUsageLimit to 500 MB for Large TIFF Files in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\Images\large_input.tif";
            string outputPath = @"C:\Images\Processed\large_output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, tiffOptions);
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
 * 1. When processing multi‑gigabyte TIFF images on a server, a developer can limit memory usage to 500 MB to prevent OutOfMemoryException.
 * 2. When converting high‑resolution scanned documents to another TIFF format in a batch job, setting MemoryUsageLimit ensures the application stays within allocated resources.
 * 3. When building a web API that receives large TIFF uploads, configuring ImageOptions.MemoryUsageLimit protects the service from crashing due to excessive memory consumption.
 * 4. When performing image manipulation such as cropping or rotating on massive medical imaging TIFF files, the memory limit helps maintain performance on machines with limited RAM.
 * 5. When integrating Aspose.Imaging into a desktop utility that processes user‑selected TIFF files, applying the 500 MB limit avoids UI freezes caused by memory overload.
 */
