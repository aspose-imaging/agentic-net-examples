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
            // Hardcoded input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add PNG files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all PNG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_filtered.png");

                // Ensure output directory for the file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image as RasterImage
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;

                    // Define a custom kernel with sum 0.9
                    double[,] kernel = new double[,]
                    {
                        { 0.05, 0.10, 0.05 },
                        { 0.10, 0.30, 0.10 },
                        { 0.05, 0.10, 0.05 }
                    };

                    // Compute the sum of the kernel elements
                    double sum = 0.0;
                    for (int i = 0; i < kernel.GetLength(0); i++)
                    {
                        for (int j = 0; j < kernel.GetLength(1); j++)
                        {
                            sum += kernel[i, j];
                        }
                    }

                    // Normalize the kernel so that its sum becomes 1.0
                    if (Math.Abs(sum) > 1e-6)
                    {
                        for (int i = 0; i < kernel.GetLength(0); i++)
                        {
                            for (int j = 0; j < kernel.GetLength(1); j++)
                            {
                                kernel[i, j] /= sum;
                            }
                        }
                    }

                    // Apply the convolution filter with the normalized kernel
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                    // Save the filtered image as PNG
                    PngOptions saveOptions = new PngOptions();
                    raster.Save(outputPath, saveOptions);
                }
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
 * 1. When a developer needs to batch‑enhance a collection of product‑catalog PNG images by applying a custom sharpening kernel that preserves overall brightness (sum 0.9) and automatically normalizes the result before saving the filtered files.
 * 2. When an application must preprocess scanned PNG documents for OCR by reducing noise with a custom convolution filter whose coefficients sum to 0.9 and then normalizing the pixel values to improve text recognition accuracy.
 * 3. When a game‑asset pipeline requires converting dozens of PNG sprite sheets using a custom edge‑detection kernel with a total weight of 0.9, followed by automatic normalization to keep sprite colors consistent across all frames.
 * 4. When a medical‑imaging tool needs to batch‑apply a low‑contrast enhancement filter to PNG radiology images, using a custom kernel with sum 0.9 and built‑in normalization to maintain diagnostic image intensity levels.
 * 5. When a web‑service automates the preparation of PNG icons for responsive design, applying a custom blur‑sharpen hybrid kernel (sum 0.9) and letting the library normalize the output so each icon retains the original visual balance.
 */