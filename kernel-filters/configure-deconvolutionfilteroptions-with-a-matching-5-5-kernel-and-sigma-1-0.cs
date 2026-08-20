// HOW-TO: Apply 5x5 Gaussian Deconvolution Filter With Sigma 1.0 In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input/input.png";
            string outputPath = "output/output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load image as RasterImage and apply deconvolution filter
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Configure a 5x5 Gaussian deconvolution filter with sigma 1.0
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 1.0);

                // Apply filter to the whole image
                raster.Filter(raster.Bounds, filterOptions);

                // Save the result as PNG
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
 * 1. When you need to reduce blur in a scanned PNG document by applying a 5×5 Gaussian deconvolution with sigma 1.0 using C#.
 * 2. When you want to enhance details in a medical imaging PNG file by performing a Wiener deconvolution filter in an Aspose.Imaging .NET application.
 * 3. When you are building an automated image‑processing pipeline that restores sharpness of batch‑processed PNG photos with a 5×5 Gaussian kernel in C#.
 * 4. When you must improve the clarity of security camera footage saved as PNG by applying a sigma 1.0 deconvolution filter before archiving it.
 * 5. When you are developing a desktop tool that lets users clean up noisy PNG graphics by running a Gaussian deconvolution filter via Aspose.Imaging for .NET.
 */
