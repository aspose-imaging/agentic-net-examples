using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        // Specified rectangular region (x, y, width, height)
        int regionX = 50;
        int regionY = 30;
        int regionWidth = 200;
        int regionHeight = 150;

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source raster image
        using (RasterImage source = (RasterImage)Image.Load(inputPath))
        {
            // Clamp the region to the source image bounds
            int x = Math.Max(0, regionX);
            int y = Math.Max(0, regionY);
            int w = Math.Min(regionWidth, source.Width - x);
            int h = Math.Min(regionHeight, source.Height - y);

            if (w <= 0 || h <= 0)
            {
                Console.Error.WriteLine("Specified region is outside the image bounds.");
                return;
            }

            // Define source rectangle
            Rectangle srcRect = new Rectangle(x, y, w, h);

            // Create a BMP canvas bound to the output file
            Source fileSource = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = fileSource };
            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, w, h))
            {
                // Load pixel data from the specified region
                int[] pixels = source.LoadArgb32Pixels(srcRect);

                // Render the region onto the canvas at (0,0)
                canvas.SaveArgb32Pixels(new Rectangle(0, 0, w, h), pixels);

                // Save the bound canvas
                canvas.Save();
            }
        }
    }
}