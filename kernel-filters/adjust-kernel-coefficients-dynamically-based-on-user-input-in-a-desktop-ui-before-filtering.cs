using System;
using System.IO;
using Aspose.Imaging;

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

            Console.WriteLine("Enter kernel size (odd integer):");
            int size = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter factor (double):");
            double factor = double.Parse(Console.ReadLine());

            int count = size * size;
            double[] flatKernel = new double[count];
            Console.WriteLine($"Enter {count} kernel coefficients separated by spaces:");
            string[] parts = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < Math.Min(count, parts.Length); i++)
            {
                flatKernel[i] = double.Parse(parts[i]);
            }

            double[,] kernel = new double[size, size];
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    kernel[y, x] = flatKernel[y * size + x];
                }
            }

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, factor, 0);
                raster.Filter(raster.Bounds, filterOptions);
                raster.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}