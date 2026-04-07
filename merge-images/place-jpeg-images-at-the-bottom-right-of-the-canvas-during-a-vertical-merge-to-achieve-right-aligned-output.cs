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
        // Hardcoded input JPEG files
        string[] inputPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };
        // Hardcoded output JPEG file
        string outputPath = "merged_output.jpg";

        // Validate each input file
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

        // Determine canvas dimensions (max width, sum of heights)
        int canvasWidth = sizes.Max(s => s.Width);
        int canvasHeight = sizes.Sum(s => s.Height);

        // Create JPEG options with bound source
        Source source = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions
        {
            Source = source,
            Quality = 100
        };

        // Create the canvas image (bound to output file)
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetY = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    // Right‑align each image
                    int offsetX = canvasWidth - img.Width;
                    Rectangle bounds = new Rectangle(offsetX, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }
            }

            // Save the bound canvas (no path needed)
            canvas.Save();
        }
    }
}