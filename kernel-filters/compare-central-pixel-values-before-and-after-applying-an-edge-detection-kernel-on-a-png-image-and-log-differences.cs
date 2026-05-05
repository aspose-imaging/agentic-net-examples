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
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                int centerX = raster.Width / 2;
                int centerY = raster.Height / 2;
                var rect = new Rectangle(centerX, centerY, 1, 1);

                // Load central pixel before filtering
                int[] beforePixels = raster.LoadArgb32Pixels(rect);
                int before = beforePixels[0];

                // Edge‑detection kernel (Laplacian)
                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 4, -1 },
                    { 0, -1, 0 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                // Load central pixel after filtering
                int[] afterPixels = raster.LoadArgb32Pixels(rect);
                int after = afterPixels[0];

                // Log difference
                if (before != after)
                {
                    Console.WriteLine($"Central pixel changed from 0x{before:X8} to 0x{after:X8}");
                }
                else
                {
                    Console.WriteLine("Central pixel unchanged.");
                }

                // Save the filtered image
                raster.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}