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
            // Hardcoded input JPEG file paths
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };

            // Hardcoded output JPEG file path
            string outputPath = "output\\combined.jpg";

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

            // Determine canvas dimensions for vertical arrangement
            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height);

            // Create JPEG canvas with bound output source
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 90 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
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
 * 1. A developer can use this code to generate a vertical photo strip for a photo booth application by stacking multiple JPEG snapshots into a single image file.
 * 2. The snippet helps create a single JPEG document from scanned page images, useful for archiving multi‑page forms as one vertical image.
 * 3. It enables assembling product photos into a continuous vertical banner for e‑commerce listings without needing external image editors.
 * 4. The code can be employed to combine sequential screenshots into a single JPEG for bug‑report attachments that require a single file.
 * 5. It allows building a printable vertical collage of event photos for a quick‑print service that expects a single JPEG output.
 */