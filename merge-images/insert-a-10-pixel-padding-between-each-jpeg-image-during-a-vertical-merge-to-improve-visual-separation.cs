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
        // Hardcoded input JPEG file paths
        string[] inputPaths = {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Hardcoded output path
        string outputPath = "merged_output.jpg";

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

        // Padding between images (10 pixels)
        int padding = 10;

        // Calculate canvas dimensions for vertical merge with padding
        int canvasWidth = sizes.Max(s => s.Width);
        int canvasHeight = sizes.Sum(s => s.Height) + padding * (sizes.Count - 1);

        // Create JPEG options with bound output source
        JpegOptions jpegOptions = new JpegOptions
        {
            Source = new FileCreateSource(outputPath, false),
            Quality = 100
        };

        // Create the output canvas bound to the file
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetY = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    // Define destination rectangle on the canvas
                    Rectangle destRect = new Rectangle(0, offsetY, img.Width, img.Height);

                    // Copy pixel data from source image to canvas
                    canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));

                    // Move offset down, adding padding after each image
                    offsetY += img.Height + padding;
                }
            }

            // Save the bound image (no path needed)
            canvas.Save();
        }
    }
}