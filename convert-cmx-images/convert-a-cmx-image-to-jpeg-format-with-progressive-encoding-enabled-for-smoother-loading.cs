// HOW-TO: Convert CMX Image to Progressive JPEG in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cmx";
            string outputPath = @"C:\Images\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CMX image with default load options
            using (Image image = Image.Load(inputPath, new CmxLoadOptions()))
            {
                // Configure JPEG save options for progressive encoding
                JpegOptions jpegOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Progressive,
                    Quality = 90 // optional quality setting
                };

                // Save as progressive JPEG
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
 * 1. When you need to display legacy CorelDRAW CMX graphics on a website, converting them to progressive JPEG reduces initial load time for users.
 * 2. When a batch processing service must transform archived CMX files into web‑friendly JPEGs with progressive rendering for smoother scrolling in image galleries.
 * 3. When an e‑commerce platform imports product illustrations saved as CMX and requires high‑quality JPEGs that load progressively on mobile devices.
 * 4. When a digital asset management system needs to generate preview thumbnails from CMX drawings and wants the previews to appear quickly using progressive JPEG compression.
 * 5. When a reporting tool creates PDF reports that embed CMX diagrams and must first convert those diagrams to progressive JPEG to keep the final document size low and rendering fast.
 */
