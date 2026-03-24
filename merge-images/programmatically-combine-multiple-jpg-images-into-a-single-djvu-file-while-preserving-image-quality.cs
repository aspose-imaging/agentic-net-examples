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
        string[] inputPaths = new string[]
        {
            @"C:\Images\page1.jpg",
            @"C:\Images\page2.jpg",
            @"C:\Images\page3.jpg"
        };

        // Hardcoded output JPEG file
        string outputPath = @"C:\Images\combined.jpg";

        // Validate input files
        foreach (var inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load all JPEG images and collect their sizes
        List<RasterImage> images = new List<RasterImage>();
        List<Size> sizes = new List<Size>();

        foreach (var path in inputPaths)
        {
            RasterImage img = (RasterImage)Image.Load(path);
            images.Add(img);
            sizes.Add(new Size(img.Width, img.Height));
        }

        // Calculate canvas size for horizontal stitching
        int canvasWidth = sizes.Sum(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        // Create JPEG options with a file source
        Source source = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions()
        {
            Source = source,
            Quality = 100
        };

        // Create a JPEG canvas
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (var img in images)
            {
                Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                offsetX += img.Width;
            }

            // Save the bound image
            canvas.Save();
        }

        // Cleanup loaded images
        foreach (var img in images)
        {
            img.Dispose();
        }
    }
}