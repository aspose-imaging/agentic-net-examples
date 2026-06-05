using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define a custom Gaussian kernel (example 5x5)
            double[,] kernel = new double[,]
            {
                { 1, 4, 7, 4, 1 },
                { 4, 16, 26, 16, 4 },
                { 7, 26, 41, 26, 7 },
                { 4, 16, 26, 16, 4 },
                { 1, 4, 7, 4, 1 }
            };

            // Normalize the kernel so that its sum equals 1 (brightness preservation)
            double sum = 0;
            foreach (double value in kernel)
                sum += value;

            if (sum != 0)
            {
                int rows = kernel.GetLength(0);
                int cols = kernel.GetLength(1);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        kernel[i, j] /= sum;
                    }
                }
            }

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply the normalized custom Gaussian kernel
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

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
 * 1. When a developer needs to reduce noise in a high‑resolution PNG screenshot while keeping the overall brightness unchanged, they can normalize a custom 5×5 Gaussian kernel and apply it with Aspose.Imaging’s ConvolutionFilterOptions.
 * 2. When building an automated batch‑processing tool that sharpens scanned PDF pages saved as PNGs, normalizing the Gaussian blur kernel ensures the blur does not darken the document before the sharpening step.
 * 3. When creating a medical imaging viewer that smooths ultrasound PNG images to hide speckle artifacts, a normalized Gaussian kernel preserves the diagnostic brightness levels across the image.
 * 4. When implementing a real‑time photo‑filter app that applies a custom blur effect to user‑uploaded PNG avatars, normalizing the kernel guarantees consistent exposure after the convolution operation.
 * 5. When developing a GIS map‑tiling service that pre‑processes PNG tiles with a Gaussian smoothing filter to reduce pixelation, kernel normalization prevents unintended brightness shifts in the rendered map.
 */