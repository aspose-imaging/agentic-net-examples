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
            // Hardcoded input image paths (JPEG files) and output path
            string[] inputPaths = new[]
            {
                "Input/image1.jpg",
                "Input/image2.jpg",
                "Input/image3.jpg"
            };
            string outputPath = "Output/merged.jpg";

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

            // First pass: collect sizes to determine canvas dimensions
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            int canvasWidth = sizes.Max(s => s.Width);               // right‑aligned width
            int canvasHeight = sizes.Sum(s => s.Height);             // total height for vertical stack

            // Create JPEG canvas bound to the output file
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions { Source = src, Quality = 100 };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        int offsetX = canvasWidth - img.Width; // right‑align each image
                        Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(offsetX, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }

                // Save the bound canvas (no need to pass path/options again)
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
 * 1. When creating a printable photo collage where each portrait‑oriented JPEG must be stacked vertically and aligned to the right edge of a single output image.
 * 2. When generating a multi‑page product catalog preview by merging individual JPEG product photos into one right‑aligned vertical strip for web display.
 * 3. When preparing a vertical banner for a digital signage system that requires all source JPEG banners to be combined into a single right‑aligned image to maintain consistent alignment.
 * 4. When automating the assembly of scanned document pages saved as JPEGs into a single right‑aligned JPEG image for archival or further processing.
 * 5. When building a C# application that consolidates user‑uploaded JPEG screenshots into a single right‑aligned vertical summary image for reporting dashboards.
 */