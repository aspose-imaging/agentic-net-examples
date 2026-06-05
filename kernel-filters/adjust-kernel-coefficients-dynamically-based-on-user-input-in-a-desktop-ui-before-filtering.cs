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
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Prompt user for kernel size (must be odd)
                Console.Write("Enter kernel size (odd integer): ");
                string sizeInput = Console.ReadLine();
                int kernelSize = int.TryParse(sizeInput, out int parsedSize) && parsedSize > 0 && parsedSize % 2 == 1
                    ? parsedSize
                    : 5; // default size

                // Prompt user for sigma value
                Console.Write("Enter sigma (double): ");
                string sigmaInput = Console.ReadLine();
                double sigma = double.TryParse(sigmaInput, out double parsedSigma) && parsedSigma > 0
                    ? parsedSigma
                    : 4.0; // default sigma

                // Create sharpen filter options with user-defined parameters
                var sharpenOptions = new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(kernelSize, sigma);

                // Apply the filter to the whole image
                raster.Filter(raster.Bounds, sharpenOptions);

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
 * 1. When a desktop application needs to let users sharpen JPEG photos by adjusting the kernel size and sigma in real time before saving the result.
 * 2. When an image‑editing tool must support custom Gaussian‑based sharpening for PNG screenshots, letting the user specify odd kernel dimensions and sigma via a UI.
 * 3. When a batch‑processing utility requires dynamic filter parameters to enhance scanned PDF page images converted to BMP, using Aspose.Imaging’s SharpenFilterOptions.
 * 4. When a photo‑management software wants to preview sharpened TIFF images with user‑controlled kernel coefficients without hard‑coding filter settings.
 * 5. When a C# WinForms program needs to apply a user‑defined sharpen filter to any raster image loaded from disk, ensuring the output path is created automatically.
 */