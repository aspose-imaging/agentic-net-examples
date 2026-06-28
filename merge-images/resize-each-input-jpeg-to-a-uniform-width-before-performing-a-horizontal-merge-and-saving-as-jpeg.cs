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
            // Hardcoded input JPEG file paths
            string[] inputPaths = new[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };

            // Hardcoded output JPEG path
            string outputPath = "merged.jpg";

            // Uniform width for each image after resizing
            int uniformWidth = 200;

            // Validate input files
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // First pass: calculate total canvas size
            int totalWidth = 0;
            int maxHeight = 0;
            foreach (string inputPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    int targetHeight = (int)Math.Round((double)img.Height * uniformWidth / img.Width);
                    totalWidth += uniformWidth;
                    if (targetHeight > maxHeight)
                        maxHeight = targetHeight;
                }
            }

            // Prepare JPEG options with bound source
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = source,
                Quality = 90
            };

            // Create canvas bound to the output file
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (string inputPath in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPath))
                    {
                        int targetHeight = (int)Math.Round((double)img.Height * uniformWidth / img.Width);
                        img.Resize(uniformWidth, targetHeight);
                        var bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the bound canvas
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
 * 1. When building a product catalog website, a developer can use this C# Aspose.Imaging code to resize each product JPEG to the same width and merge them side‑by‑side into a single thumbnail strip for quick visual browsing.
 * 2. When generating a social‑media collage, the code ensures all uploaded JPEG photos are uniformly scaled and horizontally combined, creating a ready‑to‑post image with consistent dimensions.
 * 3. When preparing an email newsletter, a developer can batch‑process multiple JPEG banners, resize them to a fixed width, and merge them into one horizontal strip to reduce email size and improve load times.
 * 4. When creating a printable banner, the code resizes each component JPEG to a uniform width and stitches them horizontally, guaranteeing a seamless layout that matches the required print specifications.
 * 5. When displaying before‑and‑after comparisons on a medical imaging portal, the developer can use this routine to align the original and processed JPEGs at the same width and merge them horizontally for easy side‑by‑side analysis.
 */