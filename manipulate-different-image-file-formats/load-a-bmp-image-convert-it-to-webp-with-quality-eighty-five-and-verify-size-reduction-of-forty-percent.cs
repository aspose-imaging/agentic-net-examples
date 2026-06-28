using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.bmp";
            string outputPath = @"C:\Images\sample_converted.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load BMP image
            using (BmpImage bmpImage = new BmpImage(inputPath))
            {
                // Set WebP conversion options (lossy with quality 85)
                var webpOptions = new WebPOptions
                {
                    Lossless = false,
                    Quality = 85f
                };

                // Save as WebP
                bmpImage.Save(outputPath, webpOptions);
            }

            // Verify size reduction of at least 40%
            long inputSize = new FileInfo(inputPath).Length;
            long outputSize = new FileInfo(outputPath).Length;

            if (outputSize <= inputSize * 0.6)
            {
                Console.WriteLine("Size reduction verification passed.");
            }
            else
            {
                Console.WriteLine("Warning: Output file size reduction is less than 40%.");
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
 * 1. When a developer needs to reduce the bandwidth of legacy BMP assets for a web application by converting them to lossy WebP at quality 85 and confirming at least a 40 % size drop.
 * 2. When an e‑commerce platform wants to batch‑process product photos stored as BMP files, generate smaller WebP thumbnails for faster page loads, and programmatically verify the compression savings.
 * 3. When a mobile game studio must shrink texture files originally saved as BMP to meet strict app‑store size limits, using Aspose.Imaging in C# to export lossy WebP with a quality setting of 85 and ensure the file size is reduced by 40 % or more.
 * 4. When a content management system migrates its image library from BMP to modern web‑friendly formats, developers can use this code to automate the conversion to WebP, apply a specific quality level, and log whether each conversion achieves the desired size reduction.
 * 5. When a DevOps pipeline includes a step that validates image optimization, the script can load BMP images, convert them to WebP with quality 85 using Aspose.Imaging for .NET, and fail the build if the resulting file is not at least 40 % smaller.
 */