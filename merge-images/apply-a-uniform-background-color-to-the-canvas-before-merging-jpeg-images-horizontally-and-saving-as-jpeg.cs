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
            string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
            string outputPath = "output.jpg";

            // Validate each input file
            foreach (var path in inputPaths)
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
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Determine canvas dimensions for horizontal merge
            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            // Create JPEG options with bound output source
            var src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = src,
                Quality = 100
            };

            // Create the canvas image
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
            {
                // Apply uniform background color
                canvas.HasBackgroundColor = true;
                canvas.BackgroundColor = Color.White;

                // Merge each image side by side
                int offsetX = 0;
                foreach (var path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the bound canvas (output path already bound via options)
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
 * 1. When creating a product catalog thumbnail that combines several product photos side‑by‑side and needs a consistent white background to avoid gaps between images.
 * 2. When generating a social‑media collage of event photos in C# where the original JPEGs have different heights and a uniform background color ensures a clean rectangular output.
 * 3. When building an automated report that merges scanned invoice pages into a single JPEG banner and requires a solid background to hide transparent areas.
 * 4. When developing a web service that stitches user‑uploaded JPEG avatars horizontally for a group chat banner, using Aspose.Imaging to set a background color so the final image looks professional.
 * 5. When preparing a printable banner that combines promotional JPEG banners of varying sizes, and a uniform background color prevents visual artifacts at the edges after merging.
 */