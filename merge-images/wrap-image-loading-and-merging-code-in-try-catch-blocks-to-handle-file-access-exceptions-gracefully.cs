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
            // Hardcoded input and output paths
            string[] inputPaths = { "input1.jpg", "input2.jpg" };
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

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = 0;
            int newHeight = 0;
            foreach (var sz in sizes)
            {
                newWidth += sz.Width;
                if (sz.Height > newHeight) newHeight = sz.Height;
            }

            // Create output image source and options
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions options = new JpegOptions() { Source = src, Quality = 90 };

            // Create canvas
            using (JpegImage canvas = (JpegImage)Image.Create(options, newWidth, newHeight))
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
 * 1. When a web service needs to combine multiple user‑uploaded JPEG photos into a single panoramic image before returning it to the client, a developer can use this code to load, validate, and merge the files while safely handling missing or locked files.
 * 2. When an automated reporting tool generates a composite image of product screenshots for a PDF catalog, the code can stitch the screenshots horizontally and ensure that absent or inaccessible image files do not crash the job.
 * 3. When a desktop application creates a side‑by‑side comparison view of before‑and‑after medical scans stored as JPEGs, the developer can employ this routine to load the scans, verify their existence, and merge them while catching file‑access exceptions.
 * 4. When a batch processing script prepares marketing banners by concatenating several promotional JPEG assets, this snippet provides a reliable way to validate each asset, merge them on a canvas, and gracefully handle permission errors.
 * 5. When a cloud function assembles a timeline collage from a list of image URLs saved locally as JPEG files, the code enables the function to load each image, compute the canvas size, and merge them while protecting against I/O failures such as missing files or locked resources.
 */