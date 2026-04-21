using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image as a raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Determine the central pixel coordinates
                int centerX = raster.Width / 2;
                int centerY = raster.Height / 2;
                Rectangle centerRect = new Rectangle(centerX, centerY, 1, 1);

                // Read the central pixel before filtering
                int[] beforePixels = raster.LoadArgb32Pixels(centerRect);
                int before = beforePixels[0];

                // Define a simple edge‑detection (Laplacian) kernel
                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 4, -1 },
                    { 0, -1, 0 }
                };

                // Apply the convolution filter using the kernel
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                // Read the central pixel after filtering
                int[] afterPixels = raster.LoadArgb32Pixels(centerRect);
                int after = afterPixels[0];

                // Log the difference if any
                if (before != after)
                {
                    Console.WriteLine($"Center pixel changed from 0x{before:X8} to 0x{after:X8}");
                }
                else
                {
                    Console.WriteLine("Center pixel unchanged after edge detection.");
                }

                // Save the processed image as PNG
                PngOptions saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}