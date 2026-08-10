// HOW-TO: Merge Multiple JPEG Images Horizontally Into One JPEG Using C# (Aspose.Imaging for .NET)
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
            // Hardcoded input directory and output file path
            string inputDirectory = "InputImages";
            string outputPath = "Output\\merged.jpg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Retrieve JPEG files from the input directory
            string[] jpgFiles = Directory.GetFiles(inputDirectory, "*.jpg");
            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpeg");
            string[] imageFiles = jpgFiles.Concat(jpegFiles).ToArray();

            if (imageFiles.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            // Validate each input file exists
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

            // Prepare JPEG options with output source
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = src,
                Quality = 90
            };

            // Create the output JPEG canvas (bound to the file)
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
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

                // Save the bound image
                canvas.Save();
            }

            Console.WriteLine($"Merged image saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to create a panoramic view by stitching a series of product photos stored as JPEGs into a single wide image for an online catalog.
 * 2. When a reporting tool must combine multiple scanned JPEG pages side‑by‑side into one image for easier preview in a web application.
 * 3. When an automated workflow has to batch‑process camera‑generated JPEG files and generate a single composite image for archival or printing.
 * 4. When a marketing script has to merge several banner JPEG assets horizontally to produce a continuous ad strip without manual editing.
 * 5. When a desktop utility must read JPEG files from a folder and output a single merged JPEG for use in slide‑show thumbnails or social‑media posts.
 */
