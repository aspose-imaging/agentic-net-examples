// HOW-TO: Convert OTG Image to JPEG with Standard Quality in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OtgToJpegConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.otg";
                string outputPath = "output.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (Image image = Image.Load(inputPath))
                {
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 75
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
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate web‑ready JPEG thumbnails from OTG graphics for an ASP.NET website.
 * 2. When integrating a document conversion service that must turn OTG template files into JPEGs for email attachments.
 * 3. When building a batch processing tool that archives OTG drawings as compressed JPEG files for long‑term storage.
 * 4. When creating a mobile app that loads OTG assets and saves them as JPEGs to reduce memory usage.
 * 5. When automating a workflow that extracts OTG diagrams from a repository and converts them to JPEG for reporting dashboards.
 */
