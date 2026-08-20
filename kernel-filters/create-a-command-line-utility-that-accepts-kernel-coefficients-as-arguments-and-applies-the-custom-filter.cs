// HOW-TO: Apply Custom Convolution Filter to PNG via Command Line in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int total = args.Length;
            int size = (int)Math.Sqrt(total);
            double[,] kernel = new double[size, size];
            for (int i = 0; i < total; i++)
            {
                int row = i / size;
                int col = i % size;
                kernel[row, col] = double.Parse(args[i]);
            }

            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 0);

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, filterOptions);
                raster.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to sharpen or blur an image by specifying a custom kernel directly from the command line in a C# automation script.
 * 2. When you want to batch‑process PNG files with a user‑defined edge‑detection filter without writing a full GUI application.
 * 3. When a CI/CD pipeline must apply a specific convolution matrix to generated screenshots before publishing them.
 * 4. When integrating Aspose.Imaging into a server‑side service that receives kernel values via API and returns a filtered PNG.
 * 5. When testing different convolution kernels quickly by passing them as arguments to a lightweight console utility.
 */
