using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    interface IKernelProvider
    {
        double[,] GetKernel();
    }

    enum EmbossSize
    {
        Size3x3,
        Size5x5
    }

    class PredefinedEmbossProvider : IKernelProvider
    {
        private readonly EmbossSize _size;

        public PredefinedEmbossProvider(EmbossSize size)
        {
            _size = size;
        }

        public double[,] GetKernel()
        {
            return _size == EmbossSize.Size3x3 ? ConvolutionFilter.Emboss3x3 : ConvolutionFilter.Emboss5x5;
        }
    }

    class CustomKernelProvider : IKernelProvider
    {
        private readonly double[,] _kernel;

        public CustomKernelProvider(double[,] kernel)
        {
            _kernel = kernel;
        }

        public double[,] GetKernel()
        {
            return _kernel;
        }
    }

    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Choose kernel provider (swap at runtime)
        // Example 1: Use predefined 3x3 emboss kernel
        IKernelProvider provider = new PredefinedEmbossProvider(EmbossSize.Size3x3);

        // Example 2: Use custom kernel (uncomment to use)
        // double[,] customKernel = new double[,] { { -2, -1, 0 }, { -1, 1, 1 }, { 0, 1, 2 } };
        // IKernelProvider provider = new CustomKernelProvider(customKernel);

        // Load image as raster image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Create convolution filter options with selected kernel
            ConvolutionFilterOptions options = new ConvolutionFilterOptions(provider.GetKernel());

            // Apply emboss filter to the whole image
            raster.Filter(raster.Bounds, options);

            // Save the processed image
            raster.Save(outputPath, new PngOptions());
        }
    }
}