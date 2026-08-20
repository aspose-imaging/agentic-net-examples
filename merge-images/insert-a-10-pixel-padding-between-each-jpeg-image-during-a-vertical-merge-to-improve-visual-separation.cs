// HOW-TO: Merge Multiple JPEG Images Vertically with 10 Pixel Padding in C# (Aspose.Imaging for .NET)
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
            // Define input JPEG files and output file
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };
            string outputPath = "output/merged.jpg";

            // Validate each input file exists
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

            // Calculate canvas dimensions (vertical merge with 10‑pixel padding)
            const int padding = 10;
            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height) + padding * (sizes.Count - 1);

            // Prepare JPEG options with bound output source
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = source,
                Quality = 100
            };

            // Create the output canvas
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string inputPath in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPath))
                    {
                        // Define destination rectangle on the canvas
                        Rectangle destRect = new Rectangle(0, offsetY, img.Width, img.Height);
                        // Copy pixel data from source image to canvas
                        canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));
                        // Move offset down, adding padding after each image
                        offsetY += img.Height + padding;
                    }
                }

                // Save the bound image (output path already set in options)
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
 * 1. When you need to create a single JPEG file that stacks product photos one below another with a small gap for an online catalog.
 * 2. When generating a printable receipt that includes scanned signatures and stamps separated by a clear space using C# and Aspose.Imaging.
 * 3. When building a photo‑timeline collage where each event picture is placed under the previous one with consistent padding for a web gallery.
 * 4. When combining scanned pages of a document into one JPEG while preserving a visual separator between pages for archival purposes.
 * 5. When preparing a vertical sprite sheet of UI icons in JPEG format, adding a 10‑pixel margin to keep each icon distinct during runtime rendering.
 */
