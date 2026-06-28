using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // List of input image files (any supported format)
            string[] inputFiles = new string[]
            {
                Path.Combine(inputDir, "image1.png"),
                Path.Combine(inputDir, "image2.bmp"),
                Path.Combine(inputDir, "image3.tif")
            };

            // Uniform JPEG quality
            int jpegQuality = 85;

            foreach (var inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path with .jpg extension
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the file into a memory stream
                using (FileStream fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
                using (MemoryStream ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    ms.Position = 0;

                    // Load image from the memory stream
                    using (Image image = Image.Load(ms))
                    {
                        // Configure JPEG options with the desired quality
                        JpegOptions jpegOptions = new JpegOptions
                        {
                            Quality = jpegQuality
                        };

                        // Save the image as JPEG
                        image.Save(outputPath, jpegOptions);
                    }
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
 * 1. When a web application captures drawings from an HTML5 Canvas, stores them in memory streams, and needs to batch‑convert them to JPEG files with a consistent quality setting for storage or download.
 * 2. When a digital asset management system receives various image formats (PNG, BMP, TIFF) from client browsers, loads them into memory streams, and must standardize them to JPEG at a uniform compression level for efficient indexing.
 * 3. When an e‑learning platform generates course screenshots on the client side, streams them to the server, and requires a C# routine to convert the batch into JPEGs with the same quality for inclusion in PDF handouts.
 * 4. When a marketing automation tool collects user‑generated graphics from HTML5 Canvas, processes them in memory, and needs to output JPEGs at a fixed quality to ensure consistent email attachment sizes.
 * 5. When a cloud‑based image‑processing pipeline receives mixed‑format canvas images via API calls, uses Aspose.Imaging to load each from a memory stream and saves them as JPEGs with a predefined quality to meet CDN bandwidth constraints.
 */