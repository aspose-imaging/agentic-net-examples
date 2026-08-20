// HOW-TO: Apply Multiple Convolution Filters Concurrently with Thread‑Safe ConvolutionFilter in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputDir = @"C:\Images\output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        try
        {
            // Define the filters to apply concurrently
            string[] filterNames = { "Sharpen3x3", "Emboss3x3", "GaussianBlur" };

            // Process each filter in parallel
            Parallel.ForEach(filterNames, filterName =>
            {
                // Load the image inside the parallel loop (each thread gets its own instance)
                using (Image image = Image.Load(inputPath, new LoadOptions { ConcurrentImageProcessing = true }))
                {
                    var raster = (RasterImage)image;

                    // Create a separate ConvolutionFilterOptions instance per thread
                    ConvolutionFilterOptions options = filterName switch
                    {
                        "Sharpen3x3" => new ConvolutionFilterOptions(ConvolutionFilter.Sharpen3x3, 1.0, 0),
                        "Emboss3x3"  => new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3, 1.0, 0),
                        "GaussianBlur" => new ConvolutionFilterOptions(
                                            ConvolutionFilter.GetGaussian(5, 1.0), // 5x5 Gaussian kernel, sigma 1.0
                                            1.0,
                                            0),
                        _ => null
                    };

                    if (options == null) return;

                    // Apply the convolution filter to the whole image
                    raster.Filter(raster.Bounds, options);

                    // Build output path and save the processed image
                    string outputPath = Path.Combine(outputDir, $"output_{filterName}.png");
                    raster.Save(outputPath);
                }
            });
        }
        catch (Exception ex)
        {
            // Unified error handling
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate sharpened, embossed, and blurred versions of the same PNG image in a batch job that runs on multiple CPU cores.
 * 2. When processing large numbers of images on a server and want to avoid race conditions by loading each image inside the parallel loop with ConcurrentImageProcessing enabled.
 * 3. When applying custom Gaussian blur kernels to images in a multi‑threaded environment without sharing filter objects between threads.
 * 4. When building a real‑time photo‑editing service that must apply different convolution effects simultaneously to improve throughput.
 * 5. When creating automated test suites that verify Aspose.Imaging’s convolution filters work correctly under parallel execution.
 */
