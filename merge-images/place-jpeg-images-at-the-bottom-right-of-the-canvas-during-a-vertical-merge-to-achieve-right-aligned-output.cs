using System;
using System.IO;
using System.Linq;
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
            // Hard‑coded input image paths
            string[] inputPaths = new[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };

            // Hard‑coded output path
            string outputPath = "output.jpg";

            // Validate each input file exists
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

            // Determine canvas dimensions for vertical, right‑aligned merge
            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height);

            // Create JPEG canvas bound to the output file
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        // Right‑align each image
                        int offsetX = canvasWidth - img.Width;
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
 * 1. When an online retailer needs to combine multiple product photos into a single right‑aligned vertical JPEG collage for a catalog page, they can use this C# Aspose.Imaging code to merge the images on a canvas that matches the widest photo.
 * 2. When a mobile app generates a vertical receipt or invoice by stacking scanned JPEG images of line items and wants the content aligned to the right edge for consistent formatting, this code creates the merged output automatically.
 * 3. When a real‑estate website wants to display a series of property interior shots as a single tall JPEG banner with each photo right‑justified, developers can employ this snippet to stitch the images vertically.
 * 4. When a social‑media scheduler needs to produce an Instagram Story image composed of several JPEG frames aligned to the right side of the canvas, the code provides a quick way to assemble the final image in C#.
 * 5. When a document management system consolidates multiple scanned JPEG pages into one vertically merged file while preserving right‑aligned layout for easier viewing on e‑readers, this Aspose.Imaging example handles the merging process.
 */