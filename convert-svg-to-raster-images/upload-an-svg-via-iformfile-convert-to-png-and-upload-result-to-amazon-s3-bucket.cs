// HOW-TO: Convert Uploaded SVG to PNG and Store in Amazon S3 Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.svg";
            string outputPath = "Output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (var pngOptions = new PngOptions())
                {
                    image.Save(outputPath, pngOptions);
                }
            }

            // Placeholder for S3 upload - not supported in this example
            throw new NotSupportedException("Uploading to Amazon S3 is not supported in this example.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web API receives an SVG file from a user (IFormFile) and needs to generate a PNG thumbnail for display on a website.
 * 2. When a backend service must convert vector graphics to raster format before storing them in an Amazon S3 bucket for CDN delivery.
 * 3. When an e‑commerce platform wants to transform vendor‑provided SVG logos into PNG images to ensure compatibility with email newsletters.
 * 4. When a mobile app uploads SVG assets to a .NET server that must compress them as PNGs and archive the results in S3 for later retrieval.
 * 5. When a document‑generation system requires converting scalable diagrams to PNG so they can be embedded in PDF reports stored in S3.
 */
