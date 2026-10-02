// HOW-TO: Create Larger Canvas and Center JPEG Images Vertically in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = "Input";
            string outputPath = "Output/merged.jpg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Get JPEG files from input directory
            string[] imageFiles = Directory.GetFiles(inputDirectory, "*.jpg");
            if (imageFiles.Length == 0)
            {
                Console.Error.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            // First pass: collect sizes
            List<Size> sizes = new List<Size>();
            int totalHeight = 0;
            int maxWidth = 0;
            foreach (string filePath in imageFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (RasterImage img = (RasterImage)Image.Load(filePath))
                {
                    sizes.Add(img.Size);
                    totalHeight += img.Height;
                    if (img.Width > maxWidth)
                        maxWidth = img.Width;
                }
            }

            // Define padding
            int padding = 20;

            // Calculate canvas size (larger than combined size)
            int canvasWidth = maxWidth + padding * 2;
            int canvasHeight = totalHeight + padding * 2;

            // Create output canvas bound to file
            Source outputSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = outputSource, Quality = 90 };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                // Fill canvas with white background (optional)
                // Not required as default may be black; to ensure white, we could clear but omitted per rules.

                int offsetY = padding;
                foreach (string filePath in imageFiles)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    using (RasterImage img = (RasterImage)Image.Load(filePath))
                    {
                        int offsetX = (canvasWidth - img.Width) / 2;
                        Rectangle bounds = new Rectangle(offsetX, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
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
 * 1. When you need to generate a single printable photo strip from multiple JPEGs while adding uniform borders around the combined image.
 * 2. When you want to create a web‑ready collage that vertically stacks product photos on a larger background to maintain consistent layout.
 * 3. When you must prepare a PDF or slide deck where each JPEG must be centered on a padded canvas before being exported as a single image.
 * 4. When you are building an automated batch process that merges scanned receipts into one tall image with equal margins for easier archiving.
 * 5. When you need to align portrait‑oriented images centrally on a custom‑size canvas for social‑media stories or Instagram reels.
 */
