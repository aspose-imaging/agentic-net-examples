using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPathSobel = "output/output_sobel.png";
            string outputPathEmboss = "output/output_emboss.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathSobel));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathEmboss));

            // Define a Sobel-like kernel (horizontal edge detection)
            double[,] sobelKernel = new double[,]
            {
                { -1, 0, 1 },
                { -2, 0, 2 },
                { -1, 0, 1 }
            };

            // Apply Sobel-like custom kernel
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(sobelKernel));
                raster.Save(outputPathSobel, new PngOptions());
            }

            // Apply built‑in Emboss3x3 kernel
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));
                raster.Save(outputPathEmboss, new PngOptions());
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
 * 1. When a developer needs to preprocess PNG photographs to highlight horizontal edges for computer‑vision feature extraction, they can compare a custom Sobel‑like convolution kernel with Aspose.Imaging’s built‑in Emboss3x3 filter.
 * 2. When building a C# desktop application that lets users preview artistic emboss effects versus true edge detection, this code demonstrates how to generate side‑by‑side output_sobel.png and output_emboss.png files.
 * 3. When evaluating the impact of different convolution kernels on medical imaging scans stored as PNG, a developer can use the example to run a Sobel‑style filter and the Emboss3x3 filter and compare the results.
 * 4. When creating an automated quality‑control pipeline that flags images with weak edge contrast, the code shows how to apply a custom Sobel kernel with Aspose.Imaging and compare it to a standard emboss filter.
 * 5. When teaching image‑processing students how to implement and benchmark custom convolution matrices versus library‑provided kernels in C#, this snippet provides a concrete, runnable example using RasterImage.Filter and PngOptions.
 */