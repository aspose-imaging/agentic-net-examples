// HOW-TO: Apply Emboss Filter With Swappable Kernels Using Dependency Injection In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

interface IEmbossKernelProvider
{
    double[,] GetKernel();
}

class PredefinedEmbossKernelProvider : IEmbossKernelProvider
{
    public double[,] GetKernel()
    {
        return ConvolutionFilter.Emboss3x3;
    }
}

class CustomEmbossKernelProvider : IEmbossKernelProvider
{
    public double[,] GetKernel()
    {
        return new double[,]
        {
            { -2, -1, 0 },
            { -1,  1, 1 },
            {  0,  1, 2 }
        };
    }
}

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

            bool useCustomKernel = true;
            IEmbossKernelProvider kernelProvider = useCustomKernel
                ? (IEmbossKernelProvider)new CustomEmbossKernelProvider()
                : new PredefinedEmbossKernelProvider();

            double[,] kernel = kernelProvider.GetKernel();

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                var options = new ConvolutionFilterOptions(kernel);
                image.Filter(image.Bounds, options);
                image.Save(outputPath, new PngOptions());
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
 * 1. When you need to let end‑users choose between a built‑in emboss effect or a custom‑designed emboss kernel without recompiling the application.
 * 2. When processing large batches of PNG images on a server and you want to switch the emboss algorithm at runtime based on configuration or user preference.
 * 3. When integrating Aspose.Imaging into a modular C# service and you want to inject different convolution kernels for testing or A/B experiments.
 * 4. When building a photo‑editing desktop app that applies an emboss filter and you require the ability to replace the kernel without changing the core image‑processing code.
 * 5. When creating automated image‑processing pipelines that must apply different emboss strengths for various product lines by swapping kernel providers through dependency injection.
 */
