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
        // Hardcoded input and output paths
        string[] inputPaths = { "image1.png", "image2.png", "image3.png" };
        string outputPath = "merged.jpg";

        // Validate input files
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

        // Calculate canvas dimensions for horizontal arrangement
        int newWidth = sizes.Sum(s => s.Width);
        int newHeight = sizes.Max(s => s.Height);

        // Create JPEG canvas bound to the output file
        Source source = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 100 };
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound JPEG image
            canvas.Save();
        }
    }
}