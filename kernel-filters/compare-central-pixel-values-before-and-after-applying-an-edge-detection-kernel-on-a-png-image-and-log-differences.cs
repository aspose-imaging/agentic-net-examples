using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for pixel operations
            RasterImage raster = (RasterImage)image;

            // Determine central pixel coordinates
            int cx = raster.Width / 2;
            int cy = raster.Height / 2;
            var centralRect = new Rectangle(cx, cy, 1, 1);

            // Read central pixel before filtering
            int[] beforePixel = raster.LoadArgb32Pixels(centralRect);

            // Apply an edge‑detection (sharpen) filter
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

            // Read central pixel after filtering
            int[] afterPixel = raster.LoadArgb32Pixels(centralRect);

            // Log pixel values and differences
            Console.WriteLine($"Before ARGB: 0x{beforePixel[0]:X8}");
            Console.WriteLine($"After  ARGB: 0x{afterPixel[0]:X8}");
            if (beforePixel[0] != afterPixel[0])
                Console.WriteLine("Pixel changed after filter.");
            else
                Console.WriteLine("Pixel unchanged after filter.");

            // Save the filtered image
            image.Save(outputPath);
        }
    }
}