using System;
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
        // Expect at least one input image and an output path
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: program.exe <input1.jpg> <input2.jpg> ... <output.jpg>");
            return;
        }

        // Last argument is the output file, the rest are input files
        string outputPath = args[args.Length - 1];
        string[] inputPaths = args.Take(args.Length - 1).ToArray();

        // Collect sizes of all input images
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Determine canvas dimensions for vertical stacking
        int canvasWidth = sizes.Max(s => s.Width);
        int canvasHeight = sizes.Sum(s => s.Height);

        // Prepare JPEG options with a file create source bound to the output path
        Source source = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions()
        {
            Source = source,
            Quality = 100 // maintain original quality
        };

        // Create a JPEG canvas with the calculated dimensions
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetY = 0;
            // Draw each image onto the canvas vertically
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }
            }

            // Since the canvas is bound to the output file via FileCreateSource, just call Save()
            canvas.Save();
        }
    }
}