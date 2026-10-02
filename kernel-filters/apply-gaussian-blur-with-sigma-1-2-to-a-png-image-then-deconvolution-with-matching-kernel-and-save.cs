// HOW-TO: Apply Gaussian Blur and Deconvolution to PNG Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

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

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var blurKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetGaussian(3, 1.2);
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(blurKernel);
                raster.Filter(raster.Bounds, blurOptions);

                var deconvOptions = new Aspose.Imaging.ImageFilters.FilterOptions.DeconvolutionFilterOptions(blurKernel);
                raster.Filter(raster.Bounds, deconvOptions);

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
 * 1. When you need to simulate a slight blur on a PNG and then restore it for testing image‑processing pipelines in C#.
 * 2. When you want to evaluate the effectiveness of deconvolution algorithms on blurred PNG assets using Aspose.Imaging.
 * 3. When preparing sample images for a computer‑vision model that requires both blurred and deblurred versions generated programmatically.
 * 4. When creating a before‑and‑after demonstration of Gaussian blur and its reversal for documentation or tutorials in .NET.
 * 5. When automating batch processing to apply and then remove blur from PNG files as part of a quality‑control workflow.
 */
