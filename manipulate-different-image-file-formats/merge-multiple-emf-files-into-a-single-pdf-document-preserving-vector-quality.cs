using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input EMF files
        string[] inputPaths = new[]
        {
            "input1.emf",
            "input2.emf",
            "input3.emf"
        };

        // Hardcoded output PDF file
        string outputPath = "merged.pdf";

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

        // Collect sizes of all EMF images
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas size (horizontal stitching)
        int canvasWidth = sizes.Sum(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        // Create an unbound raster canvas (JPEG image) to hold merged content
        JpegOptions canvasOptions = new JpegOptions();
        using (JpegImage canvas = (JpegImage)Image.Create(canvasOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    // Copy pixels from EMF rasterized image onto the canvas
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the merged canvas as a PDF
            canvas.Save(outputPath);
        }
    }
}