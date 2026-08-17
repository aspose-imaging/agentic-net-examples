// HOW-TO: Create a Larger Canvas and Center JPEG Images Vertically in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input JPEG files
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };

            // Hardcoded output file
            string outputPath = "output/merged.jpg";

            // Validate input files
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Determine canvas dimensions (larger than combined size)
            int maxWidth = sizes.Max(s => s.Width);
            int totalHeight = sizes.Sum(s => s.Height);
            int padding = 20; // extra space around and between images

            int canvasWidth = maxWidth + padding * 2;
            int canvasHeight = totalHeight + padding * (inputPaths.Length + 1);

            // Create JPEG options with bound output source
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = new FileCreateSource(outputPath, false),
                Quality = 100
            };

            // Create canvas bound to the output file
            using (JpegImage canvas = new JpegImage(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = padding;

                // Merge each image vertically, centered horizontally
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        int offsetX = (canvasWidth - img.Width) / 2; // center horizontally
                        Rectangle bounds = new Rectangle(offsetX, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height + padding;
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
 * 1. When you need to combine multiple product photos into a single high‑resolution JPEG with uniform padding for an online catalog.
 * 2. When generating a printable collage of scanned documents where each page must be centered on a larger background canvas.
 * 3. When preparing a vertical banner that stacks several advertisement JPEGs with consistent margins for a web page.
 * 4. When creating a composite image for a report that requires all source JPEGs aligned centrally on a common canvas.
 * 5. When automating the assembly of receipt images into one file while preserving original dimensions and adding whitespace around them.
 */
