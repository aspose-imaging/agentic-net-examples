// HOW-TO: Convert JPEG to Progressive JPEG to Reduce File Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output\\output_progressive.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            JpegOptions jpegOptions = new JpegOptions
            {
                CompressionType = JpegCompressionMode.Progressive
            };

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to optimize web‑served photos by converting standard JPEGs to progressive JPEGs to achieve smaller file sizes without losing quality using C# and Aspose.Imaging.
 * 2. When preparing product catalog images for faster loading on mobile devices, you can re‑save them as progressive JPEGs to reduce bandwidth consumption.
 * 3. When generating email newsletters, converting attached JPEGs to progressive format helps keep the email size low while preserving visual fidelity.
 * 4. When building a batch image‑processing pipeline that must standardize all JPEGs to a progressive compression mode for consistent rendering across browsers.
 * 5. When comparing compression techniques, you can use this code to measure how progressive JPEG compression impacts file size versus baseline JPEGs.
 */
