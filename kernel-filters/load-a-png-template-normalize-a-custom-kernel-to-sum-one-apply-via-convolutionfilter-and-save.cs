using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "template.png";
        string outputPath = "output/output.png";

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

                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                double sum = 0;
                for (int y = 0; y < kernel.GetLength(0); y++)
                {
                    for (int x = 0; x < kernel.GetLength(1); x++)
                    {
                        sum += kernel[y, x];
                    }
                }

                if (sum != 0)
                {
                    for (int y = 0; y < kernel.GetLength(0); y++)
                    {
                        for (int x = 0; x < kernel.GetLength(1); x++)
                        {
                            kernel[y, x] /= sum;
                        }
                    }
                }

                var filterOptions = new ConvolutionFilterOptions(kernel, 1.0, 0);
                raster.Filter(raster.Bounds, filterOptions);

                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}