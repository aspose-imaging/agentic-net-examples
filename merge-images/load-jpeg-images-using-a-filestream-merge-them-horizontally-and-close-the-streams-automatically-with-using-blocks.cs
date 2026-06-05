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
            // Hardcoded input and output paths
            string[] inputPaths = new string[] { "input1.jpg", "input2.jpg", "input3.jpg" };
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
                using (FileStream stream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
                using (JpegImage img = new JpegImage(stream))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Create JPEG options with bound output source
            Source outputSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = outputSource,
                Quality = 100
            };

            // Create canvas image
            using (JpegImage canvas = new JpegImage(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (string inputPath in inputPaths)
                {
                    using (FileStream stream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
                    using (JpegImage img = new JpegImage(stream))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
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
 * 1. When a web service needs to generate a single panoramic thumbnail by loading multiple JPEG files with FileStream and merging them horizontally into one image.
 * 2. When an e‑commerce platform wants to create a side‑by‑side collage of customer‑uploaded JPEG photos using JpegImage objects and automatic disposal via using blocks.
 * 3. When a desktop publishing tool assembles several scanned JPEG pages into one wide canvas for a printable proof sheet, calculating canvas size from each image’s dimensions.
 * 4. When a batch‑processing script for wildlife monitoring merges daily camera‑trap JPEG pictures into a horizontal strip for inclusion in a report.
 * 5. When a digital signage system combines multiple advertisement JPEG banners into a single wide image to be displayed on a large screen.
 */