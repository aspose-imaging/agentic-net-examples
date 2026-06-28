using System;
using System.IO;
using System.Collections.Generic;
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
            string[] inputPaths = new string[]
            {
                "Input\\image1.jpg",
                "Input\\image2.jpg",
                "Input\\image3.jpg"
            };
            string outputPath = "Output\\merged.jpg";

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

            // Collect sizes of all images
            List<Size> sizes = new List<Size>();
            foreach (string inputPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions (horizontal merge, top‑left alignment)
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (Size sz in sizes)
            {
                canvasWidth += sz.Width;
                if (sz.Height > canvasHeight) canvasHeight = sz.Height;
            }

            // Create JPEG canvas with bound output file
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = new FileCreateSource(outputPath, false),
                Quality = 100
            };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (string inputPath in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPath))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
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
 * 1. When generating a product catalog thumbnail that stitches multiple product photos side‑by‑side into a single JPEG for faster web loading.
 * 2. When creating a printable contact sheet where several scanned JPEG images need to be placed horizontally with top‑left alignment to maintain consistent margins.
 * 3. When building a dashboard that combines real‑time camera snapshots into one JPEG banner, ensuring each snapshot starts at the top‑left corner of the canvas.
 * 4. When preparing a batch of marketing assets that require merging brand‑logo JPEGs with promotional images into a single file with uniform alignment for automated publishing.
 * 5. When developing a mobile app that concatenates user‑uploaded JPEG pictures into a single image for sharing, needing top‑left placement to avoid gaps and preserve layout.
 */