using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPEG file paths
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Hardcoded output JPEG file path
        string outputPath = "output.jpg";

        // Validate each input file exists
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas size for horizontal merging
        int newWidth = 0;
        int newHeight = 0;
        foreach (Size sz in sizes)
        {
            newWidth += sz.Width;
            if (sz.Height > newHeight)
                newHeight = sz.Height;
        }

        // Create an unbound BMP canvas
        BmpOptions bmpOptions = new BmpOptions();
        using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, newWidth, newHeight))
        {
            // Merge images side by side
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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the merged canvas as JPEG
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = new FileCreateSource(outputPath, false),
                Quality = 90
            };
            canvas.Save(outputPath, jpegOptions);
        }
    }
}