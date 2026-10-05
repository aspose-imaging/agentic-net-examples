// HOW-TO: Convert JPEG to YCbCr Color Space and Save in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.jpg";
            string outputPath = "Output\\sample_converted.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (JpegOptions jpegOptions = new JpegOptions())
                {
                    jpegOptions.Source = new FileCreateSource(outputPath, false);
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
 * 1. When you need to ensure a JPEG image uses the YCbCr color model for compatibility with web browsers or printing pipelines.
 * 2. When you want to re‑encode an existing JPEG while preserving its original quality but explicitly control the color type for downstream processing.
 * 3. When a batch job must convert user‑uploaded photos to a standardized YCbCr format before performing color‑based analysis.
 * 4. When integrating Aspose.Imaging into a C# application that prepares images for JPEG‑compatible devices that require YCbCr encoding.
 * 5. When troubleshooting color shift issues by saving a JPEG with a known color space to compare against the original.
 */
