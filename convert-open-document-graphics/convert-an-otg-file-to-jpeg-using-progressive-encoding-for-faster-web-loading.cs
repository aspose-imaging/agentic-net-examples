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
            string inputPath = "Input/sample.otg";
            string outputPath = "Output/sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            using (JpegOptions jpegOptions = new JpegOptions())
            {
                // Set progressive JPEG compression
                jpegOptions.CompressionType = JpegCompressionMode.Progressive;

                // Configure vector rasterization for OTG
                OtgRasterizationOptions otgRasterizationOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };
                jpegOptions.VectorRasterizationOptions = otgRasterizationOptions;

                // Save as JPEG
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
 * 1. When a web developer needs to display vector‑based OTG diagrams on a website and wants faster page loads by serving progressive JPEG images.
 * 2. When an e‑commerce platform must convert product schematics stored as OTG files into web‑friendly JPEG thumbnails that load incrementally for better user experience.
 * 3. When a mobile app generates OTG charts on the server and requires them to be rasterized and saved as progressive JPEGs to reduce bandwidth consumption on slow networks.
 * 4. When a content management system automates the ingestion of OTG assets and needs to store them as progressive JPEG files for SEO‑optimized image indexing.
 * 5. When a reporting tool exports OTG‑based technical drawings to JPEG with progressive compression so that large images can be previewed instantly in browsers.
 */