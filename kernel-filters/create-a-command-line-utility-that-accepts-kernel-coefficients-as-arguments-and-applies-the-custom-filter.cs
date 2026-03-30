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

        // Parse kernel coefficients from command‑line arguments
        double[] flatKernel = args.Select(a => double.Parse(a)).ToArray();

        // Determine kernel size (assumes square kernel)
        int size = (int)Math.Sqrt(flatKernel.Length);
        if (size * size != flatKernel.Length)
        {
            // Fallback: treat as 1‑D kernel with size equal to length (non‑square)
            size = flatKernel.Length;
        }

        // Build 2D kernel array
        double[,] kernel2D = new double[size, size];
        for (int i = 0; i < flatKernel.Length; i++)
        {
            int row = i / size;
            int col = i % size;
            kernel2D[row, col] = flatKernel[i];
        }

        double factor = 1.0; // default factor

        // Load image, apply custom convolution filter, and save
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            var filterOptions = new ConvolutionFilterOptions(kernel2D, factor);
            raster.Filter(raster.Bounds, filterOptions);

            raster.Save(outputPath, new PngOptions());
        }
    }
}