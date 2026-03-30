using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

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

        // Load brush stroke image to generate custom kernel
        double[,] kernel;
        const int kernelSize = 5; // Example kernel size

        using (Image brushImage = Image.Load(inputPath))
        {
            RasterImage brushRaster = (RasterImage)brushImage;

            // Extract a region (top-left) as the kernel source
            var region = new Rectangle(0, 0, kernelSize, kernelSize);
            int[] argbPixels = brushRaster.LoadArgb32Pixels(region);

            // Convert ARGB pixels to grayscale intensity and normalize
            kernel = new double[kernelSize, kernelSize];
            double sum = 0;
            for (int y = 0; y < kernelSize; y++)
            {
                for (int x = 0; x < kernelSize; x++)
                {
                    int argb = argbPixels[y * kernelSize + x];
                    // Extract blue channel as intensity (could use any channel)
                    double intensity = (argb & 0xFF) / 255.0;
                    kernel[y, x] = intensity;
                    sum += intensity;
                }
            }

            // Normalize kernel so that sum equals 1 (avoid brightness change)
            if (sum != 0)
            {
                for (int y = 0; y < kernelSize; y++)
                {
                    for (int x = 0; x < kernelSize; x++)
                    {
                        kernel[y, x] /= sum;
                    }
                }
            }
        }

        // Load target PNG image and apply the custom convolution filter
        using (Image targetImage = Image.Load(inputPath))
        {
            RasterImage targetRaster = (RasterImage)targetImage;

            // Apply custom kernel
            var filterOptions = new ConvolutionFilterOptions(kernel);
            targetRaster.Filter(targetRaster.Bounds, filterOptions);

            // Save the result as PNG
            var pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };
            targetImage.Save(outputPath, pngOptions);
        }
    }
}