using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string[] inputPaths = { "input1.jpg", "input2.jpg" };
        string outputPath = "output.jpg";

        try
        {
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
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (var path in inputPaths)
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal stitching
            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            // Create output source and JPEG options
            FileCreateSource source = new FileCreateSource(outputPath, false);
            JpegOptions options = new JpegOptions() { Source = source, Quality = 90 };

            // Create a JPEG canvas bound to the output file
            using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(options, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (var path in inputPaths)
                {
                    using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                    {
                        Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
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
 * 1. When an e‑commerce platform needs to automatically stitch multiple product photos into a single high‑quality JPEG banner, this C# Aspose.Imaging code can merge the images while gracefully handling missing files or access errors.
 * 2. When a travel blog wants to generate panoramic views by concatenating a series of JPEG snapshots taken on a trip, the code creates a horizontal canvas and writes the result with configurable quality, protecting against read/write exceptions.
 * 3. When a document management system scans multi‑page forms as separate JPEG files and must combine them into one image for archival, the routine validates each page, merges them, and catches file‑access issues to avoid processing interruptions.
 * 4. When a marketing team automates the creation of social‑media collages from user‑submitted images, the program loads each JPEG, assembles them side‑by‑side, and uses try‑catch blocks to handle permission problems on the server.
 * 5. When a desktop application generates printable photo strips from a set of camera‑generated JPEGs, the code calculates the canvas size, stitches the images, and ensures any missing or locked files are reported without crashing the app.
 */