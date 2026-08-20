// HOW-TO: Normalize Gaussian Kernel and Preserve Brightness When Applying Blur in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths.
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

        // Verify the input file exists.
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists.
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the image.
            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;

                // 1. Automatic adaptive brightness/contrast normalization.
                raster.AutoBrightnessContrast();

                // 2. Histogram normalization to use the full dynamic range.
                raster.NormalizeHistogram();

                // 3. Apply a custom Gaussian kernel with explicit normalization.
                //    The raw kernel may not sum to 1, which can shift overall brightness.
                double[,] rawKernel = ConvolutionFilter.GetGaussian(5, 1.0);

                // Compute the sum of all kernel elements.
                double sum = 0;
                foreach (double v in rawKernel) sum += v;

                // Create a normalized kernel where the sum equals 1.
                double[,] normKernel = new double[rawKernel.GetLength(0), rawKernel.GetLength(1)];
                for (int i = 0; i < rawKernel.GetLength(0); i++)
                {
                    for (int j = 0; j < rawKernel.GetLength(1); j++)
                    {
                        normKernel[i, j] = rawKernel[i, j] / sum;
                    }
                }

                // Apply the normalized kernel using ConvolutionFilterOptions.
                var convOptions = new ConvolutionFilterOptions(normKernel);
                raster.Filter(raster.Bounds, convOptions);

                // Save the processed image.
                raster.Save(outputPath);
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
 * 1. When you need to automatically adjust the brightness and contrast of a PNG before further processing, such as preparing images for a web gallery.
 * 2. When you want to stretch the image’s histogram to use the full dynamic range so that dark and light areas are fully visible in reports.
 * 3. When applying a Gaussian blur to an image and must keep the overall brightness unchanged by normalizing the convolution kernel.
 * 4. When processing batches of images on a server and need to ensure the output folder exists and missing input files are handled gracefully.
 * 5. When you require a reproducible C# workflow that combines auto‑brightness, histogram normalization, and a custom normalized filter for medical or scientific imaging pipelines.
 */
