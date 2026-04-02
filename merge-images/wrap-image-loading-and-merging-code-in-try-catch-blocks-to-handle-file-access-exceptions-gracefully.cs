using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath1 = "input1.png";
        string inputPath2 = "input2.png";
        string inputPath3 = "input3.png";
        string outputPath = "output.png";

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
        if (!File.Exists(inputPath3))
        {
            Console.Error.WriteLine($"File not found: {inputPath3}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Collect sizes of all images
        var sizes = new List<Size>();
        using (RasterImage img1 = (RasterImage)Image.Load(inputPath1))
        {
            sizes.Add(img1.Size);
        }
        using (RasterImage img2 = (RasterImage)Image.Load(inputPath2))
        {
            sizes.Add(img2.Size);
        }
        using (RasterImage img3 = (RasterImage)Image.Load(inputPath3))
        {
            sizes.Add(img3.Size);
        }

        // Calculate canvas dimensions for horizontal merge
        int newWidth = sizes.Sum(s => s.Width);
        int newHeight = sizes.Max(s => s.Height);

        // Create output image options
        FileCreateSource source = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions() { Source = source };

        // Create canvas
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            foreach (string path in new[] { inputPath1, inputPath2, inputPath3 })
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    var bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the merged image (bound to the source)
            canvas.Save();
        }
    }
}