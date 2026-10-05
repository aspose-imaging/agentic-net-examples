// HOW-TO: Resize Multiple JPEGs to Same Width and Merge Horizontally in C# (Aspose.Imaging for .NET)
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
            string[] inputPaths = new string[] { "input1.jpg", "input2.jpg", "input3.jpg" };
            string outputPath = "output.jpg";

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

            const int targetWidth = 200; // uniform width for all images

            List<RasterImage> resizedImages = new List<RasterImage>();
            List<Size> sizes = new List<Size>();

            // Load, resize, and collect sizes
            foreach (string path in inputPaths)
            {
                using (JpegImage img = (JpegImage)Image.Load(path))
                {
                    int newHeight = (int)Math.Round((double)img.Height * targetWidth / img.Width);
                    img.Resize(targetWidth, newHeight, ResizeType.NearestNeighbourResample);
                    // Clone the resized image into a new RasterImage to keep after disposing original
                    RasterImage cloned = (RasterImage)Image.Create(new JpegOptions(), img.Width, img.Height);
                    cloned.SaveArgb32Pixels(new Rectangle(0, 0, img.Width, img.Height), img.LoadArgb32Pixels(img.Bounds));
                    resizedImages.Add(cloned);
                    sizes.Add(new Size(cloned.Width, cloned.Height));
                }
            }

            // Calculate canvas size for horizontal merge
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Create output JPEG canvas
            Source outSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = outSource, Quality = 90 };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (RasterImage img in resizedImages)
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                    img.Dispose();
                }
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
 * 1. When creating a photo strip for a web gallery, you need to resize several JPEG photos to a common width and stitch them side‑by‑side into a single JPEG image.
 * 2. When generating printable product labels that combine multiple product photos, you must standardize the width of each JPEG and merge them horizontally before saving.
 * 3. When building a thumbnail carousel where each thumbnail must have identical dimensions, you can resize the source JPEGs to the same width and concatenate them into one image for efficient loading.
 * 4. When preparing before‑and‑after comparison images for a marketing email, you need to align the before and after JPEGs by width and combine them horizontally into a single file.
 * 5. When automating batch processing of scanned receipts to create a single page view, you resize each receipt JPEG to a uniform width and merge them side‑by‑side using C# and Aspose.Imaging.
 */
