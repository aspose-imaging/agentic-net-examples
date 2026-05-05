using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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

            // Define the 3x3 kernel with center weight 0.7 and surrounding weights 0.075
            double[,] kernel = new double[3, 3]
            {
                { 0.075, 0.075, 0.075 },
                { 0.075, 0.7,   0.075 },
                { 0.075, 0.075, 0.075 }
            };

            // Normalize the kernel so that the sum of all weights equals 1
            double sum = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    sum += kernel[i, j];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    kernel[i, j] /= sum;

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                var pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}