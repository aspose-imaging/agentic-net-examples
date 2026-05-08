using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory and output file
            string inputDirectory = "Input";
            string outputPath = "Output/merged.jpg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Get all JPEG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.jpg");

            if (files.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            // Lists to hold rotated images and their dimensions
            List<Aspose.Imaging.RasterImage> rotatedImages = new List<Aspose.Imaging.RasterImage>();
            List<int> widths = new List<int>();
            List<int> heights = new List<int>();

            // Load each image, rotate it, and store for merging
            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                // Load as RasterImage
                Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(filePath);
                // Rotate 90 degrees clockwise
                img.RotateFlip(Aspose.Imaging.RotateFlipType.Rotate90FlipNone);

                rotatedImages.Add(img);
                widths.Add(img.Width);
                heights.Add(img.Height);
            }

            // Determine canvas size for vertical merge
            int canvasWidth = widths.Max();
            int canvasHeight = heights.Sum();

            // Create JPEG canvas with bound source
            FileCreateSource source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                // Paste each rotated image onto the canvas
                foreach (Aspose.Imaging.RasterImage img in rotatedImages)
                {
                    var bounds = new Aspose.Imaging.Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                    img.Dispose(); // Dispose after copying
                }

                // Save the final merged image
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}