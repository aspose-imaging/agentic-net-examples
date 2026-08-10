// HOW-TO: Create Progressive JPEG From BMP And Reduce File Size In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.bmp";
            string outputPath = @"C:\Images\sample_progressive.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options with progressive compression
                JpegOptions saveOptions = new JpegOptions
                {
                    BitsPerChannel = 8,
                    CompressionType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionMode.Progressive,
                    Quality = 90, // reasonable quality
                    ResolutionSettings = new ResolutionSetting(96.0, 96.0),
                    ResolutionUnit = ResolutionUnit.Inch
                };

                // Save the image as progressive JPEG
                image.Save(outputPath, saveOptions);
            }

            // Report file size of the saved JPEG
            long fileSize = new FileInfo(outputPath).Length;
            Console.WriteLine($"Saved progressive JPEG size: {fileSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to serve web images that load gradually, converting BMP files to progressive JPEGs reduces initial download time and improves user experience.
 * 2. When migrating legacy bitmap assets to a smaller, web‑friendly format, you can preserve visual quality while cutting storage space using progressive JPEG compression in C#.
 * 3. When optimizing server storage, generating progressive JPEGs lets you compare file size reductions against baseline JPEGs for bandwidth‑saving decisions.
 * 4. When preparing images for email newsletters, progressive JPEGs display a low‑resolution preview as the message loads, enhancing perceived performance.
 * 5. When building an automated C# image‑processing pipeline, setting the JPEG CompressionType to Progressive standardizes resolution and creates smaller files for faster delivery.
 */
