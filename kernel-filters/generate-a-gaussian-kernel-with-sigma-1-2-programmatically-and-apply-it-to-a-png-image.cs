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
            string outputPath = "output\\output.png";

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

                // Apply Gaussian blur with kernel size 5 and sigma 1.2
                int kernelSize = 5; // must be odd
                double sigma = 1.2;
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(kernelSize, sigma);
                raster.Filter(raster.Bounds, blurOptions);

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
 * 1. When a developer needs to reduce image noise in a PNG file before performing OCR, they can generate a Gaussian kernel with sigma 1.2 and apply the blur using Aspose.Imaging for .NET.
 * 2. When preparing product photos for an e‑commerce website, a C# program can apply a Gaussian blur with a 5×5 kernel and sigma 1.2 to smooth edges while preserving overall detail.
 * 3. When creating thumbnail previews of high‑resolution PNG assets, applying a Gaussian blur with sigma 1.2 helps to soften visual artifacts before resizing.
 * 4. When implementing a custom image‑processing pipeline that requires consistent blur strength across different PNG inputs, developers can programmatically generate the Gaussian kernel and apply it with Aspose.Imaging’s Filter method.
 * 5. When integrating image preprocessing into a machine‑learning workflow, a developer can use this code to blur PNG training images with a sigma of 1.2 to improve model robustness to noise.
 */