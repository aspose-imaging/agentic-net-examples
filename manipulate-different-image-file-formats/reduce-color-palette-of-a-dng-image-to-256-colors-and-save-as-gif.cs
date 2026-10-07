// HOW-TO: Convert DNG to 256‑Color GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.dng";
            string outputPath = "Output\\result.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DngImage dng = (DngImage)Image.Load(inputPath))
            {
                if (!dng.IsCached)
                {
                    dng.CacheData();
                }

                using (GifOptions gifOptions = new GifOptions())
                {
                    dng.Save(outputPath, gifOptions);
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
 * 1. When a photographer needs to create a web‑friendly preview of a high‑resolution DNG raw file by reducing it to a 256‑color GIF for faster loading.
 * 2. When an e‑commerce platform wants to generate low‑size GIF thumbnails from DNG product images to display on product listings.
 * 3. When a mobile app must convert raw DNG captures into GIFs with a limited palette to meet platform file‑size restrictions.
 * 4. When a digital archive requires batch conversion of DNG scans into GIFs for compatibility with legacy systems that only support 8‑bit images.
 * 5. When a developer is building a reporting tool that embeds DNG images as GIFs in PDF or HTML reports to ensure consistent rendering across browsers.
 */
