using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached) image.CacheData();
                image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to convert a JPEG photograph to a lossless PNG before applying graph‑cut segmentation, this code loads the raster image, caches it, and saves it as PNG.
 * 2. When an application must ensure that an input image is cached in memory to avoid repeated disk reads during intensive processing, the code demonstrates how to check and invoke image caching.
 * 3. When a workflow requires validating the existence of an input file and automatically creating the output directory for the converted image, the example shows the necessary file‑system checks and directory creation.
 * 4. When a .NET service processes user‑uploaded images and needs to standardize them to PNG format for consistent downstream analysis, this snippet provides a simple C# implementation.
 * 5. When troubleshooting image‑format compatibility issues in a pipeline that only accepts PNG files, the code offers a quick way to re‑encode JPEGs while handling exceptions gracefully.
 */