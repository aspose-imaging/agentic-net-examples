// HOW-TO: Merge Multiple JPEG Images Horizontally Aligned Top Left in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input JPEG file paths
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };

            // Verify each input file exists
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal layout (top‑left alignment)
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (Size sz in sizes)
            {
                canvasWidth += sz.Width;
                if (sz.Height > canvasHeight)
                    canvasHeight = sz.Height;
            }

            // Hardcoded output path
            string outputPath = "merged_output.jpg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare JPEG options with bound file source
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = src, Quality = 100 };

            // Create canvas image bound to the output file
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the bound canvas to the file
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
 * 1. When you need to create a single panoramic JPEG from several photos taken side‑by‑side for a web gallery.
 * 2. When generating a product catalog page that places product thumbnail JPEGs next to each other with consistent top‑left alignment.
 * 3. When preparing a printable banner where multiple JPEG advertisements must be stitched horizontally without gaps.
 * 4. When building a reporting tool that combines chart images into one JPEG row for email distribution.
 * 5. When automating the creation of a composite image for a slideshow thumbnail that shows several JPEG frames aligned at the top left.
 */
