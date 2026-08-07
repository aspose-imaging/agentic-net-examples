// HOW-TO: Vertically Merge JPEG Images With 10 Pixel Padding In C# (Aspose.Imaging for .NET)
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
            // Hardcoded input JPEG files
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };
            // Hardcoded output path
            string outputPath = "output.jpg";

            // Validate each input file exists
            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Determine canvas dimensions with 10‑pixel padding between images
            int canvasWidth = 0;
            int canvasHeight = 0;
            int padding = 10;
            foreach (var sz in sizes)
            {
                if (sz.Width > canvasWidth) canvasWidth = sz.Width;
                canvasHeight += sz.Height;
            }
            canvasHeight += padding * (sizes.Count - 1);

            // Create JPEG canvas bound to the output file
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions options = new JpegOptions() { Source = src, Quality = 100 };
            using (JpegImage canvas = new JpegImage(options, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (var path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height + padding;
                    }
                }
                // Save the merged image
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
 * 1. When creating a photo collage for a product catalog and each JPEG must be stacked with a small gap to keep the images visually distinct.
 * 2. When generating a single printable receipt image from multiple scanned JPEG pages, adding padding to separate each page clearly.
 * 3. When building a web gallery thumbnail that combines several JPEG screenshots vertically while preserving a margin to avoid content overlap.
 * 4. When preparing a multi‑section report where each section is a JPEG chart and a 10‑pixel space improves readability in the combined image.
 * 5. When automating the creation of a vertical banner from separate JPEG ads, inserting a thin margin to separate each ad visually.
 */
