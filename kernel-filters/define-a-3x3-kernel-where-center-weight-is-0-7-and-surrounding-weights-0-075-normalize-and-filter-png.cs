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
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define 3x3 kernel with center 0.7 and surrounding 0.075, then normalize.
                double[,] kernel = new double[3, 3];
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        kernel[y, x] = 0.075;
                    }
                }
                kernel[1, 1] = 0.7;

                double sum = 0.7 + 8 * 0.075; // 1.3
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        kernel[y, x] /= sum;
                    }
                }

                // Apply custom convolution filter.
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                // Save the filtered image as PNG.
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
 * 1. When a developer wants to reduce noise in a PNG screenshot while preserving edges by applying a custom 3×3 convolution kernel in C# with Aspose.Imaging.
 * 2. When an application needs to smooth a product photo saved as PNG before uploading it to an e‑commerce site, using a normalized kernel where the center weight is 0.7.
 * 3. When a batch‑processing tool must apply a subtle blur to scanned PNG documents to improve OCR accuracy, leveraging Aspose.Imaging’s Filter method.
 * 4. When a game asset pipeline requires a lightweight sharpening‑plus‑smoothing filter for PNG textures, implemented with a 3×3 kernel and normalized convolution in .NET.
 * 5. When a medical‑imaging viewer needs to preprocess PNG X‑ray images to even out illumination without over‑blurring, using a custom kernel and Aspose.Imaging’s convolution filter.
 */