using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
        string outputPath = "output.jpg";

        // Validate each input file exists
        foreach (var path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Collect sizes of all input images
        var sizes = new List<Aspose.Imaging.Size>();
        foreach (var path in inputPaths)
        {
            using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for vertical merge
        int newWidth = 0;
        int newHeight = 0;
        foreach (var sz in sizes)
        {
            if (sz.Width > newWidth) newWidth = sz.Width;
            newHeight += sz.Height;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create JPEG options with 4:2:0 subsampling
        FileCreateSource source = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions()
        {
            Source = source,
            Quality = 90,
            HorizontalSampling = new byte[] { 2, 1, 1 }, // 4:2:0
            VerticalSampling = new byte[] { 2, 1, 1 }    // 4:2:0
        };

        // Create bound JPEG canvas and merge images vertically
        using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(jpegOptions, newWidth, newHeight))
        {
            int offsetY = 0;
            foreach (var path in inputPaths)
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                {
                    var bounds = new Aspose.Imaging.Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }
            }

            // Save the bound image (output path already set in options)
            canvas.Save();
        }
    }
}