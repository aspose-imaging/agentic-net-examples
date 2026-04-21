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
        try
        {
            // Hardcoded input and output paths
            string inputPath1 = "input1.jpg";
            string inputPath2 = "input2.jpg";
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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG images as raster images
            using (RasterImage img1 = (RasterImage)Image.Load(inputPath1))
            using (RasterImage img2 = (RasterImage)Image.Load(inputPath2))
            {
                // Collect sizes
                List<Size> sizes = new List<Size>();
                sizes.Add(img1.Size);
                sizes.Add(img2.Size);

                // Calculate canvas dimensions (horizontal merge)
                int newWidth = sizes.Sum(s => s.Width);
                int newHeight = sizes.Max(s => s.Height);

                // Create PNG options with bound source
                Source src = new FileCreateSource(outputPath, false);
                PngOptions pngOptions = new PngOptions() { Source = src };

                // Create canvas
                using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, newWidth, newHeight))
                {
                    // Merge first image at (0,0)
                    Rectangle bounds1 = new Rectangle(0, 0, img1.Width, img1.Height);
                    canvas.SaveArgb32Pixels(bounds1, img1.LoadArgb32Pixels(img1.Bounds));

                    // Merge second image to the right of the first
                    int offsetX = img1.Width;
                    Rectangle bounds2 = new Rectangle(offsetX, 0, img2.Width, img2.Height);
                    canvas.SaveArgb32Pixels(bounds2, img2.LoadArgb32Pixels(img2.Bounds));

                    // Save the merged PNG (source is already bound)
                    canvas.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}