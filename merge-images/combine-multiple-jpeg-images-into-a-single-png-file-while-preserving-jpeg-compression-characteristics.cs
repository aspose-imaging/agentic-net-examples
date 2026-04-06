using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
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

        // Hardcoded output PNG file path
        string outputPath = "output.png";

        // Validate each input file exists
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

        // Calculate canvas dimensions (horizontal concatenation)
        int canvasWidth = sizes.Sum(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        // Prepare PNG options with bound output source
        Source pngSource = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions() { Source = pngSource };

        // Create PNG canvas and merge JPEG images onto it
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    // Load ARGB pixels from the JPEG image
                    int[] pixels = img.LoadArgb32Pixels(img.Bounds);

                    // Define destination rectangle on the canvas
                    Rectangle destRect = new Rectangle(offsetX, 0, img.Width, img.Height);

                    // Paste pixels onto the canvas
                    canvas.SaveArgb32Pixels(destRect, pixels);

                    offsetX += img.Width;
                }
            }

            // Save the bound PNG image
            canvas.Save();
        }
    }
}