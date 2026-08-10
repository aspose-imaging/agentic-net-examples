// HOW-TO: Apply Blur, Emboss, and Sharpen Filters to JPEG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image as a raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply a blur box filter (size 5)
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.GetBlurBox(5)));

                // Apply an emboss filter (3x3 emboss kernel)
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Apply a sharpen filter (kernel size 5, sigma 4.0)
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the processed image as JPEG
                JpegOptions jpegOptions = new JpegOptions();
                raster.Save(outputPath, jpegOptions);
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
 * 1. When you need to create a stylized product photo by blurring, embossing, and sharpening a JPEG before uploading to an e‑commerce site.
 * 2. When you want to preprocess scanned documents to enhance edges and add artistic texture using Aspose.Imaging filters in a C# batch job.
 * 3. When building a photo‑editing desktop app that applies a combination of blur, emboss, and sharpen effects to user‑selected images.
 * 4. When generating thumbnails with a distinctive look for a gallery, applying multiple convolution filters to the original JPEG in .NET.
 * 5. When automating image preparation for a marketing campaign, chaining blur, emboss, and sharpen filters to achieve a high‑contrast, soft‑focus effect.
 */
