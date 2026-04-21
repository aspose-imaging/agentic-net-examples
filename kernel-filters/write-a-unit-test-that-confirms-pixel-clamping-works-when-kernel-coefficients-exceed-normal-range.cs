using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "test_input.png";
            string outputPath = "test_output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a 2x2 test image with known pixel values
            using (Image img = Image.Create(new PngOptions(), 2, 2))
            {
                RasterImage raster = (RasterImage)img;
                int[] pixels = new int[]
                {
                    unchecked((int)0xFF000000), // Black
                    unchecked((int)0xFFFFFFFF), // White
                    unchecked((int)0xFF808080), // Gray
                    unchecked((int)0xFF404040)  // Dark gray
                };
                var fullRect = new Rectangle(0, 0, 2, 2);
                raster.SaveArgb32Pixels(fullRect, pixels);
                raster.Save(inputPath, new PngOptions());
            }

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image and apply a sharpen filter with exaggerated factor to trigger clamping
            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;

                var sharpenOptions = new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0);
                sharpenOptions.Factor = 20; // Exaggerated factor to push pixel values beyond normal range

                raster.Filter(raster.Bounds, sharpenOptions);

                // Retrieve pixel data after filtering
                var fullRect = new Rectangle(0, 0, raster.Width, raster.Height);
                int[] resultPixels = raster.LoadArgb32Pixels(fullRect);

                // Verify each channel is within 0-255
                bool clamped = resultPixels.All(p =>
                {
                    int a = (p >> 24) & 0xFF;
                    int r = (p >> 16) & 0xFF;
                    int g = (p >> 8) & 0xFF;
                    int b = p & 0xFF;
                    return a >= 0 && a <= 255 && r >= 0 && r <= 255 && g >= 0 && g <= 255 && b >= 0 && b <= 255;
                });

                if (clamped)
                {
                    Console.WriteLine("Pixel clamping test passed.");
                }
                else
                {
                    Console.Error.WriteLine("Pixel clamping test failed: out-of-range values detected.");
                }

                // Save the filtered image
                raster.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}