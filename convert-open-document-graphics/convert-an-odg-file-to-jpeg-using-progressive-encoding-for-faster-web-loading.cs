using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.odg";
        string outputPath = @"C:\temp\sample_converted.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG options for progressive encoding
                JpegOptions jpegOptions = new JpegOptions
                {
                    CompressionType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionMode.Progressive,
                    Quality = 100 // Maximum quality; adjust as needed
                };

                // Save as JPEG with the specified options
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
 * 1. When a web developer needs to display vector graphics from an OpenDocument (.odg) file as fast‑loading JPEG images on a website, they can use this code to convert the ODG to a progressive JPEG.
 * 2. When an e‑learning platform must generate thumbnail previews of user‑uploaded ODG diagrams for course catalogs, the snippet provides a C# way to create high‑quality progressive JPEGs for quick preview rendering.
 * 3. When a content management system has to batch‑process archived ODG illustrations into web‑optimized JPEGs with progressive encoding to reduce perceived load time, this example shows the necessary Aspose.Imaging calls.
 * 4. When a mobile app needs to download vector drawings from an OpenDocument source and display them as JPEGs that load incrementally on slow connections, the code demonstrates how to perform the conversion in C#.
 * 5. When a digital asset pipeline requires converting design assets stored as ODG files into progressive JPEGs for SEO‑friendly image indexing, this sample illustrates the required file format conversion and compression settings.
 */