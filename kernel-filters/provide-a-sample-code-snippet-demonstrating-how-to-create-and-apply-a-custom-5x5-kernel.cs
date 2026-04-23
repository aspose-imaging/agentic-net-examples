using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define a custom 5x5 kernel (example: simple sharpening kernel)
                double[,] kernel = new double[5, 5]
                {
                    { -1, -1, -1, -1, -1 },
                    { -1,  2,  2,  2, -1 },
                    { -1,  2,  8,  2, -1 },
                    { -1,  2,  2,  2, -1 },
                    { -1, -1, -1, -1, -1 }
                };

                // Apply the custom convolution filter to the entire image
                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                raster.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}