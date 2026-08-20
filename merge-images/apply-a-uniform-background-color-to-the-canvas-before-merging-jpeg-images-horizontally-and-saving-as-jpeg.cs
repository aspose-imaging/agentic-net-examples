// HOW-TO: Merge Multiple JPEG Images Horizontally with White Background in C# (Aspose.Imaging for .NET)
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
            string[] inputPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };
            string outputPath = "merged.jpg";

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

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (string inputPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Create JPEG canvas with background color
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 100 };
            using (JpegImage canvas = new JpegImage(jpegOptions, canvasWidth, canvasHeight))
            {
                // Set uniform background color
                canvas.BackgroundColor = Color.White;
                canvas.HasBackgroundColor = true;
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                graphics.Clear(Color.White);

                // Merge images horizontally
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
 * 1. When you need to combine product photos side‑by‑side into a single JPEG with a consistent white backdrop for an online catalog.
 * 2. When generating a panoramic view from several JPEG screenshots and want the canvas to fill empty space with a uniform color.
 * 3. When creating a printable brochure that stitches multiple JPEG advertisements together and requires a solid background to avoid transparent gaps.
 * 4. When automating batch processing of JPEG thumbnails to produce a single composite image for a gallery page, ensuring the background matches the site theme.
 * 5. When developing a C# application that merges user‑uploaded JPEG images horizontally and must set a specific background color before saving the final file.
 */
