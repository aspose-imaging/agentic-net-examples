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
            string inputDirectory = "InputImages";
            string outputPath = "Output/merged.jpg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Get JPEG files from the input directory
            string[] imageFiles = Directory.GetFiles(inputDirectory, "*.jpg");

            // Validate each input file
            foreach (string filePath in imageFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }
            }

            // Collect sizes of all images
            List<Size> sizes = new List<Size>();
            foreach (string filePath in imageFiles)
            {
                using (RasterImage img = (RasterImage)Image.Load(filePath))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            // Create JPEG canvas
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 90 };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
            {
                // Merge images horizontally
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
 * 1. When creating a product catalog thumbnail that stitches several product photos side‑by‑side into one JPEG for faster web loading.
 * 2. When generating a panoramic view from a series of sequential camera shots by horizontally concatenating JPEG images in a C# application using Aspose.Imaging.
 * 3. When building an email newsletter that needs a single banner image composed of multiple promotional JPEGs merged on a horizontal canvas.
 * 4. When preparing a printable contact sheet where a photographer wants all selected JPEG files arranged in one row for quick review.
 * 5. When automating a batch process that consolidates scanned document pages saved as JPEGs into a single wide image for archival or OCR preprocessing.
 */