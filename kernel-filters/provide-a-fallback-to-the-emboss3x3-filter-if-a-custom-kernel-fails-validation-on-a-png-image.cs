using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output\\result.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Attempt to apply a custom convolution kernel
                double[,] customKernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                try
                {
                    var customOptions = new ConvolutionFilterOptions(customKernel);
                    raster.Filter(raster.Bounds, customOptions);
                }
                catch (Exception)
                {
                    // Fallback to built‑in Emboss3x3 filter if custom kernel fails
                    var fallbackOptions = new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3);
                    raster.Filter(raster.Bounds, fallbackOptions);
                }

                // Save the processed image as PNG
                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When a photo‑editing desktop app lets users upload a PNG and apply a custom sharpening kernel, but the kernel dimensions are invalid, the code automatically falls back to the built‑in Emboss3x3 filter to ensure the image is still processed.
 * 2. When an automated batch‑processing service reads PNG files from a folder and attempts to enhance them with a user‑defined convolution matrix, the fallback guarantees that each file is saved even if the matrix fails validation.
 * 3. When a web API receives a PNG payload and tries to apply a custom edge‑detection kernel, the fallback to Emboss3x3 prevents the request from failing due to malformed kernel data.
 * 4. When a mobile‑to‑desktop synchronization tool converts PNG screenshots and attempts to apply a custom contrast‑boost kernel, the code ensures a graceful fallback to Emboss3x3 if the kernel is out of the allowed value range.
 * 5. When a scientific imaging pipeline processes PNG microscopy images with a custom convolution filter for noise reduction, the fallback to Emboss3x3 maintains workflow continuity when the custom kernel does not meet Aspose.Imaging validation rules.
 */