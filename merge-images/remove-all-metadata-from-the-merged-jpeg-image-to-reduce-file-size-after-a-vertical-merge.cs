// HOW-TO: Merge Two JPEG Images Vertically and Strip Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath1 = @"input\img1.jpg";
            string inputPath2 = @"input\img2.jpg";
            string outputPath = @"output\merged.jpg";

            // Validate input files
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect image sizes
            List<string> inputPaths = new List<string> { inputPath1, inputPath2 };
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas size for vertical merge
            int newWidth = sizes.Max(s => s.Width);
            int newHeight = sizes.Sum(s => s.Height);

            // Create JPEG options with metadata removal
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = source,
                Quality = 100,
                KeepMetadata = false
            };

            // Create bound JPEG canvas
            using (JpegImage canvas = new JpegImage(jpegOptions, newWidth, newHeight))
            {
                int offsetY = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }

                // Save the merged image (canvas is already bound to the output source)
                canvas.Save();
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
 * 1. When you need to combine scanned document pages into a single JPEG for easier distribution while removing EXIF data to keep the file size small.
 * 2. When creating a photo collage from multiple portrait shots in a mobile app and you want to eliminate metadata for privacy before uploading.
 * 3. When generating a vertical sprite sheet for a game and you must discard unnecessary JPEG metadata to meet bandwidth constraints.
 * 4. When automating batch processing of product photos to produce a single tall image for a catalog, and you want to strip metadata to comply with GDPR.
 * 5. When preparing images for email newsletters where a single merged JPEG reduces attachments and metadata removal avoids leaking camera information.
 */
