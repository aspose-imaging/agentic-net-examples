// HOW-TO: Optimize Large JPEG Loading and Reduce File Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\large.jpg";
            string outputPath = "Output\\large_optimized.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions { BufferSizeHint = 10 * 1024 * 1024 };

            using (JpegImage image = (JpegImage)Image.Load(inputPath, loadOptions))
            {
                using (var jpegOptions = new JpegOptions())
                {
                    jpegOptions.Quality = 75;
                    jpegOptions.CompressionType = JpegCompressionMode.Baseline;
                    image.Save(outputPath, jpegOptions);
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
 * 1. When a web application must display high‑resolution photos but needs to limit memory consumption while loading them on the server.
 * 2. When a batch‑processing tool has to shrink large JPEG assets for faster download without noticeably degrading visual quality.
 * 3. When an e‑commerce platform wants to generate thumbnail‑ready images from original product photos while keeping the process memory‑efficient.
 * 4. When a mobile backend service processes user‑uploaded pictures and must store them with reduced file size to save storage costs.
 * 5. When a digital asset management system needs to re‑encode legacy JPEG files with a lower quality setting and baseline compression to ensure compatibility across devices.
 */
