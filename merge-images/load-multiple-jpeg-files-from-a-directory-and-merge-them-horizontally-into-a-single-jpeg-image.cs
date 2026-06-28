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
            string inputDirectory = "InputImages";
            string outputPath = "Output/merged.jpg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Get JPEG files from the input directory
            string[] imageFiles = Directory.GetFiles(inputDirectory, "*.jpg");

            // Collect sizes of all images
            List<Size> sizes = new List<Size>();
            foreach (string filePath in imageFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (RasterImage img = (RasterImage)Image.Load(filePath))
                {
                    sizes.Add(img.Size);
                }
            }

            if (sizes.Count == 0)
            {
                Console.WriteLine("No JPEG files found to merge.");
                return;
            }

            // Calculate canvas dimensions for horizontal merge
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Create JPEG canvas with specified options
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 90 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (string filePath in imageFiles)
                {
                    using (RasterImage img = (RasterImage)Image.Load(filePath))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the merged image (bound image)
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
 * 1. When creating a product catalog thumbnail that shows several product photos side‑by‑side in a single JPEG for an e‑commerce website.
 * 2. When generating a before‑and‑after comparison image for a medical imaging report by stitching two JPEG scans horizontally.
 * 3. When building a social media collage that combines user‑uploaded JPEG pictures into one wide image for a marketing campaign.
 * 4. When preparing a printable banner that requires multiple JPEG graphics to be merged horizontally into a single high‑quality JPEG file.
 * 5. When automating the creation of a timeline infographic where each event’s JPEG icon is placed next to the previous one in a single image.
 */