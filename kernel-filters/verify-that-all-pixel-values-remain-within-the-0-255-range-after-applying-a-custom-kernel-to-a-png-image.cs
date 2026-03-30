using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

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
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Cast to RasterImage for pixel manipulation
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

            // Define a custom 3x3 convolution kernel (edge detection example)
            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            // Apply the custom kernel using ConvolutionFilterOptions
            var filterOptions = new ConvolutionFilterOptions(kernel);
            raster.Filter(raster.Bounds, filterOptions);

            // Verify that all pixel channel values are within 0‑255
            int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
            bool allValid = true;
            foreach (int argb in pixels)
            {
                byte a = (byte)((argb >> 24) & 0xFF);
                byte r = (byte)((argb >> 16) & 0xFF);
                byte g = (byte)((argb >> 8) & 0xFF);
                byte b = (byte)(argb & 0xFF);

                if (a > 255 || r > 255 || g > 255 || b > 255)
                {
                    allValid = false;
                    break;
                }
            }

            Console.WriteLine(allValid
                ? "All pixel values are within the 0‑255 range."
                : "Pixel values out of range detected.");

            // Save the processed image as PNG
            var saveOptions = new PngOptions();
            raster.Save(outputPath, saveOptions);
        }
    }
}