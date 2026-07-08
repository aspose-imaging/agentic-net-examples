using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input and output directories (hard‑coded)
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Gather JPEG files
            string[] files = Directory.GetFiles(inputDirectory, "*.*")
                                      .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                                  f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                                      .ToArray();

            if (files.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            // Validate each file exists
            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }
            }

            // First pass: determine square size for each image
            List<int> squareSizes = new List<int>();
            foreach (string filePath in files)
            {
                using (RasterImage img = (RasterImage)Image.Load(filePath))
                {
                    if (!img.IsCached) img.CacheData();
                    int size = Math.Min(img.Width, img.Height);
                    squareSizes.Add(size);
                }
            }

            // Canvas dimensions (vertical merge of squares)
            int canvasWidth = squareSizes.Max();
            int canvasHeight = squareSizes.Sum();

            // Output path
            string outputPath = Path.Combine(outputDirectory, "merged.png");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create an unbound PNG canvas
            PngOptions pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                for (int i = 0; i < files.Length; i++)
                {
                    string filePath = files[i];
                    int size = squareSizes[i];

                    using (RasterImage img = (RasterImage)Image.Load(filePath))
                    {
                        if (!img.IsCached) img.CacheData();

                        // Crop to square region (top‑left)
                        img.Crop(new Rectangle(0, 0, size, size));

                        // Copy pixels onto canvas
                        canvas.SaveArgb32Pixels(
                            new Rectangle(0, offsetY, size, size),
                            img.LoadArgb32Pixels(img.Bounds));

                        offsetY += size;
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
 * 1. When a developer needs to generate a printable PDF portfolio of product photos where each JPEG must be centered and uniformly square before stacking vertically.
 * 2. When an e‑learning platform wants to combine student‑submitted JPEG screenshots into a single PDF report with a consistent square thumbnail layout.
 * 3. When a real‑estate website creates a PDF brochure that vertically lists square‑cropped property images extracted from JPEG files.
 * 4. When a marketing automation script prepares a PDF catalog of campaign images, ensuring each JPEG is cropped to a central square and merged in order.
 * 5. When a document management system converts a folder of scanned JPEG receipts into a single PDF, aligning each receipt as a centered square image for easy viewing.
 */