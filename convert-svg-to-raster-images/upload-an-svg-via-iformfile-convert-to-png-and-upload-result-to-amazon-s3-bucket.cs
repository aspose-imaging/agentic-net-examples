// HOW-TO: Convert Uploaded SVG to PNG and Store in Amazon S3 Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.svg";
            string outputPath = "Output\\sample.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG from file stream
            using (FileStream inputStream = File.OpenRead(inputPath))
            using (SvgImage svgImage = new SvgImage(inputStream))
            {
                // Configure rasterization options
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White
                };

                // Configure PNG save options
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save rasterized PNG
                svgImage.Save(outputPath, pngOptions);
            }

            // Placeholder for Amazon S3 upload logic
            // The PNG file at 'outputPath' should be uploaded to the desired S3 bucket here.
            // Implementation would typically use AWS SDK or a presigned URL with HttpClient,
            // but external libraries are not permitted in this example.
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application receives vector graphics from users and needs to generate raster PNG thumbnails for display.
 * 2. When an e‑commerce platform must transform customer‑uploaded SVG logos into PNG files before saving them to a cloud storage bucket.
 * 3. When a reporting service converts scalable diagrams into PNG images to embed them in PDF reports stored on Amazon S3.
 * 4. When a content‑management system processes SVG icons uploaded via a form and archives the rasterized PNG versions in an S3 bucket for CDN delivery.
 * 5. When a mobile backend receives SVG assets, rasterizes them to PNG for compatibility, and uploads the results to S3 for later retrieval by client apps.
 */
