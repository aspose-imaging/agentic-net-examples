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
            string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
            // Hardcoded output JPEG file path
            string outputPath = "output/combined.jpg";

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

            // Calculate canvas dimensions for vertical arrangement
            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height);

            // Create JPEG canvas with specified options
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 90 };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                // Merge each image onto the canvas vertically
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }

                // Save the combined image (bound image saves to the source defined in options)
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
 * 1. When a developer needs to generate a vertical JPEG collage of several product images for an e‑commerce catalog using C# and Aspose.Imaging.
 * 2. When a developer wants to stitch scanned JPEG pages into one continuous vertical document for archival or printing purposes.
 * 3. When a developer must combine multiple user‑uploaded JPEG screenshots into a single tall image for a social‑media post or tutorial guide.
 * 4. When a developer is building a photo‑journalism web app that merges a series of JPEG photos taken throughout an event into one vertical timeline image.
 * 5. When a developer automates the creation of a vertical JPEG banner by stacking promotional images for email newsletters or digital signage.
 */