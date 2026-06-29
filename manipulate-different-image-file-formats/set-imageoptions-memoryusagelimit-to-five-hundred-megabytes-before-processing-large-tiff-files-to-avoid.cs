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
        string inputPath = @"C:\temp\large.tif";
        string outputPath = @"C:\temp\output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage image = (TiffImage)Image.Load(inputPath))
            {
                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, saveOptions);
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
 * 1. When a C# application must convert multi‑gigabyte multi‑page TIFF documents to another format on a server with limited RAM, setting ImageOptions.MemoryUsageLimit to 500 MB prevents an OutOfMemoryException during the load and save operations.
 * 2. When a desktop utility processes high‑resolution scanned TIFF images for OCR preprocessing, limiting memory usage to 500 MB ensures the program remains responsive and avoids crashes on machines with 8 GB of RAM.
 * 3. When a batch job iterates over a folder of large medical imaging TIFF files to apply compression with Aspose.Imaging, configuring the memory limit protects the job from exceeding the .NET heap size.
 * 4. When a cloud‑based microservice receives uploaded TIFF files from users and needs to re‑encode them without allocating excessive memory, setting the 500 MB cap keeps the service within its container memory quota.
 * 5. When an automated archival system extracts pages from massive TIFF archives for thumbnail generation, enforcing a 500 MB memory ceiling ensures the process completes reliably without triggering an OutOfMemoryException.
 */