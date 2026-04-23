using System;
using System.IO;
using System.Linq;

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

            double[] flatKernel = args.Select(a => double.Parse(a)).ToArray();

            int size = (int)Math.Sqrt(flatKernel.Length);
            if (size * size != flatKernel.Length || size == 0)
            {
                size = 3;
            }

            double[,] kernel = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int index = i * size + j;
                    kernel[i, j] = index < flatKernel.Length ? flatKernel[index] : 0.0;
                }
            }

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 0);
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