using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image and cast to RasterImage
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Configure DeconvolutionFilterOptions with a 5x5 kernel and sigma 1.0
                var deconvOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 1.0);

                // Apply the filter to the entire image
                raster.Filter(raster.Bounds, deconvOptions);

                // Save the processed image
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
 * 1. When a developer needs to reduce blur and noise in scanned PNG documents before OCR by applying a 5×5 Gaussian Wiener deconvolution filter with sigma 1.0 using Aspose.Imaging for .NET.
 * 2. When an image‑processing pipeline must enhance the clarity of medical X‑ray PNG files by deconvolving a known point‑spread function with a 5×5 kernel and sigma 1.0 in a C# application.
 * 3. When a photo‑editing tool built with C# has to restore detail in low‑light PNG pictures by applying a Gauss‑Wiener filter with a 5×5 kernel and sigma 1.0 before saving the result.
 * 4. When an automated quality‑control system for printed circuit board images needs to remove motion blur from PNG captures using a 5×5 deconvolution kernel with sigma 1.0 via Aspose.Imaging.
 * 5. When a batch‑processing script must uniformly sharpen a collection of PNG assets for a game UI by configuring DeconvolutionFilterOptions with a 5×5 kernel and sigma 1.0 in .NET.
 */