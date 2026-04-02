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
        string[] inputPaths = {
            @"C:\Images\input1.jpg",
            @"C:\Images\input2.jpg",
            @"C:\Images\input3.jpg"
        };
        string outputPath = @"C:\Images\combined_output.jpg";

        // Verify each input file exists
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
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (string path in inputPaths)
        {
            using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Determine canvas dimensions for vertical stacking
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (var sz in sizes)
        {
            if (sz.Width > canvasWidth) canvasWidth = sz.Width;
            canvasHeight += sz.Height;
        }

        // Create output source and JPEG options
        var source = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions()
        {
            Source = source,
            Quality = 90
        };

        // Create the canvas image
        using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetY = 0;
            foreach (string path in inputPaths)
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                {
                    Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }
            }

            // Save the combined image (source is already bound)
            canvas.Save();
        }
    }
}