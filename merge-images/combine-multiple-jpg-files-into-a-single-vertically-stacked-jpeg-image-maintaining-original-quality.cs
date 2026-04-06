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
        // Hardcoded input JPG file paths
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Hardcoded output path for the combined image
        string outputPath = "output/combined.jpg";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Validate each input file exists and collect its size
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }

            using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Determine canvas dimensions for vertical stacking
        int canvasWidth = sizes.Max(s => s.Width);
        int canvasHeight = sizes.Sum(s => s.Height);

        // Create JPEG options with the output source
        FileCreateSource source = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions()
        {
            Source = source,
            Quality = 100 // maintain original quality
        };

        // Create a JPEG canvas bound to the output file
        using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetY = 0;

            // Paste each image onto the canvas vertically
            foreach (string path in inputPaths)
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                {
                    var bounds = new Aspose.Imaging.Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }
            }

            // Save the bound JPEG image
            canvas.Save();
        }
    }
}