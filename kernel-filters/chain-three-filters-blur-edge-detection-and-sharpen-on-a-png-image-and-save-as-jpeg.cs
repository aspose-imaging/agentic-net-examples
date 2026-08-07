using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output/output.jpg";

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

                // Apply Gaussian blur filter
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Apply edge detection using a Sobel kernel (convolution filter)
                double[,] sobelKernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(sobelKernel));

                // Apply sharpen filter
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the result as JPEG
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90
                };
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
 * 1. When a developer needs to preprocess a PNG screenshot by blurring, detecting edges, and sharpening before converting it to a high‑quality JPEG for inclusion in a web report.
 * 2. When an e‑commerce platform must automatically enhance product photos—applying Gaussian blur to reduce noise, Sobel edge detection to highlight contours, and sharpening—while saving the final image as a JPEG for faster page loads.
 * 3. When a medical imaging application requires batch conversion of PNG scans into JPEGs with a custom filter pipeline to improve visual clarity for remote diagnosis.
 * 4. When a game developer wants to generate stylized JPEG thumbnails from PNG assets by chaining blur, edge detection, and sharpen filters using Aspose.Imaging in C#.
 * 5. When a content management system needs to transform uploaded PNG graphics into optimized JPEGs with a three‑step filter process to ensure consistent visual quality across browsers.
 */