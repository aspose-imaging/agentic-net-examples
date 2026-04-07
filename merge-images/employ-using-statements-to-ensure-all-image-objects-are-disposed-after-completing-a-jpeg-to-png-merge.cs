using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string jpegPath = "input.jpg";
        string pngPath = "input.png";
        string outputPath = "output.png";

        // Validate input files
        if (!File.Exists(jpegPath))
        {
            Console.Error.WriteLine($"File not found: {jpegPath}");
            return;
        }
        if (!File.Exists(pngPath))
        {
            Console.Error.WriteLine($"File not found: {pngPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load both images and collect their sizes
        List<Size> sizes = new List<Size>();
        using (RasterImage jpegImg = (RasterImage)Image.Load(jpegPath))
        {
            sizes.Add(jpegImg.Size);
            using (RasterImage pngImg = (RasterImage)Image.Load(pngPath))
            {
                sizes.Add(pngImg.Size);

                // Calculate canvas dimensions for horizontal merge
                int newWidth = sizes[0].Width + sizes[1].Width;
                int newHeight = Math.Max(sizes[0].Height, sizes[1].Height);

                // Create a PNG canvas bound to the output file
                Source src = new FileCreateSource(outputPath, false);
                PngOptions pngOptions = new PngOptions() { Source = src };
                using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, newWidth, newHeight))
                {
                    // Copy JPEG image onto the left side of the canvas
                    Rectangle jpegBounds = new Rectangle(0, 0, jpegImg.Width, jpegImg.Height);
                    canvas.SaveArgb32Pixels(jpegBounds, jpegImg.LoadArgb32Pixels(jpegImg.Bounds));

                    // Copy PNG image onto the right side of the canvas
                    Rectangle pngBounds = new Rectangle(jpegImg.Width, 0, pngImg.Width, pngImg.Height);
                    canvas.SaveArgb32Pixels(pngBounds, pngImg.LoadArgb32Pixels(pngImg.Bounds));

                    // Save the merged image (bound to the output path)
                    canvas.Save();
                }
            }
        }
    }
}