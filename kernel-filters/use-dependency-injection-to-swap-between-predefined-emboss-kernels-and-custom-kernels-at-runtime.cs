using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
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

            bool usePredefined = true; // Change to false to use custom kernel

            IKernelProvider kernelProvider = usePredefined
                ? (IKernelProvider)new PredefinedEmbossKernelProvider()
                : new CustomKernelProvider();

            double[,] kernel = kernelProvider.GetKernel();

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
                var filterOptions = new ConvolutionFilterOptions(kernel);
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

interface IKernelProvider
{
    double[,] GetKernel();
}

class PredefinedEmbossKernelProvider : IKernelProvider
{
    public double[,] GetKernel()
    {
        // Use the 3x3 emboss kernel provided by Aspose.Imaging
        return ConvolutionFilter.Emboss3x3;
    }
}

class CustomKernelProvider : IKernelProvider
{
    public double[,] GetKernel()
    {
        // Example custom emboss-like kernel
        return new double[,]
        {
            { -2, -1, 0 },
            { -1,  1, 1 },
            {  0,  1, 2 }
        };
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to apply an emboss effect to PNG files and wants to toggle between Aspose.Imaging’s built‑in Emboss3x3 kernel and a custom kernel without changing the core processing code, they can use this dependency‑injection approach.
 * 2. When a C# application must support user‑defined emboss filters for photo‑editing tools, the IKernelProvider interface lets the runtime select a custom matrix supplied by the user.
 * 3. When a batch‑processing service processes thousands of images and must switch to a faster predefined kernel for performance‑critical runs, the boolean flag combined with DI enables seamless kernel swapping.
 * 4. When integrating Aspose.Imaging into a plug‑in architecture where different modules provide their own convolution kernels, the IKernelProvider pattern allows each module to inject its kernel at execution time.
 * 5. When testing image‑processing algorithms, developers can inject the PredefinedEmbossKernelProvider for baseline results and the CustomKernelProvider for experimental kernels to compare visual outcomes.
 */