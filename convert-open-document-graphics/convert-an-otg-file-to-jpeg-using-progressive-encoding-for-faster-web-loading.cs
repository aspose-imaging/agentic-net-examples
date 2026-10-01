// HOW-TO: Convert OTG to Progressive JPEG for Faster Web Loading in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.otg";
            string outputPath = "Output\\sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Progressive,
                    Quality = 90
                };

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
 * 1. When a web application needs to display high‑resolution OTG graphics as smaller, progressively loading JPEGs to improve page load speed.
 * 2. When an e‑commerce platform must convert product design files in OTG format to web‑optimized JPEGs with quality control for faster image rendering.
 * 3. When a content management system processes uploaded OTG assets and saves them as progressive JPEGs to reduce bandwidth consumption on mobile devices.
 * 4. When a batch‑processing tool automates the migration of legacy OTG images to JPEG format with progressive encoding for SEO‑friendly image delivery.
 * 5. When a digital publishing workflow requires converting OTG illustrations to JPEG with a specific quality setting to maintain visual fidelity while enabling progressive download.
 */
