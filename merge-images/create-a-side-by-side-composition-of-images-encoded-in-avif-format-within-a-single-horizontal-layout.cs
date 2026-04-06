using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath1 = "input1.avif";
        string inputPath2 = "input2.avif";
        string outputPath = "output.jpg";

        // Validate input files
        if (!File.Exists(inputPath1))
        {
            Console.Error.WriteLine($"File not found: {inputPath1}");
            return;
        }
        if (!File.Exists(inputPath2))
        {
            Console.Error.WriteLine($"File not found: {inputPath2}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Collect sizes of input images
        var sizes = new List<Aspose.Imaging.Size>();
        using (RasterImage img1 = (RasterImage)Image.Load(inputPath1))
        {
            sizes.Add(img1.Size);
        }
        using (RasterImage img2 = (RasterImage)Image.Load(inputPath2))
        {
            sizes.Add(img2.Size);
        }

        // Calculate canvas dimensions for horizontal layout
        int newWidth = 0;
        int newHeight = 0;
        foreach (var sz in sizes)
        {
            newWidth += sz.Width;
            if (sz.Height > newHeight) newHeight = sz.Height;
        }

        // Create output source and JPEG options
        Source outSource = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions() { Source = outSource, Quality = 90 };

        // Create canvas and merge images side by side
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            foreach (string path in new[] { inputPath1, inputPath2 })
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    var bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }
            // Save the bound image
            canvas.Save();
        }
    }
}