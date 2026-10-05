using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class ConvolutionKernels
{
    public static readonly double[,] Emboss3x3 = ConvolutionFilter.Emboss3x3;
    public static readonly double[,] Sharpen3x3 = ConvolutionFilter.Sharpen3x3;
    public static readonly double[,] BlurBox5 = ConvolutionFilter.GetBlurBox(5);
}

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

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                {
                    image.CacheData();
                }

                // Apply emboss filter using predefined kernel
                image.Filter(image.Bounds, new ConvolutionFilterOptions(ConvolutionKernels.Emboss3x3));

                // Save the result
                image.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}