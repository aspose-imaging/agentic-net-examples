// HOW-TO: Increase BMP Smoothing By Applying 7x7 Blur Box In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image as a raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Create a 7x7 blur box kernel
                double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurBox(7);

                // Prepare convolution filter options with the custom kernel
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                // Apply the blur filter to the entire image
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                // Save the processed image as BMP
                var bmpOptions = new BmpOptions();
                rasterImage.Save(outputPath, bmpOptions);
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
 * 1. When you need to reduce noise in a BMP photograph by applying a stronger blur effect using a 7x7 convolution kernel in a C# application.
 * 2. When you want to preprocess scanned BMP documents to smooth out grainy edges before performing OCR, using Aspose.Imaging’s blur box filter.
 * 3. When a game developer must generate a softened background texture from a BMP asset by increasing the blur kernel size for a more gradual fade.
 * 4. When an automated image pipeline requires consistent smoothing of BMP files across a batch, and you need to adjust the kernel from the default 3x3 to 7x7 for better results.
 * 5. When you are building a C# tool that saves the blurred output back to BMP format, preserving the original file type while enhancing visual softness.
 */
