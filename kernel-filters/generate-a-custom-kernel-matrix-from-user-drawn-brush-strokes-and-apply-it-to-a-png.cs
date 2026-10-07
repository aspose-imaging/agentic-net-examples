// HOW-TO: Create Custom Convolution Kernel from Brush Strokes and Apply to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

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

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                Console.WriteLine("Enter odd kernel size (e.g., 3,5,7):");
                if (!int.TryParse(Console.ReadLine(), out int size) || size % 2 == 0 || size <= 0)
                {
                    Console.Error.WriteLine("Invalid kernel size.");
                    return;
                }

                double[,] kernel = new double[size, size];
                Console.WriteLine($"Enter {size * size} kernel values (row‑major order), one per line:");
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (!double.TryParse(Console.ReadLine(), out double value))
                        {
                            Console.Error.WriteLine("Invalid kernel value.");
                            return;
                        }
                        kernel[i, j] = value;
                    }
                }

                var filterOptions = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                var saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, saveOptions);
            }

            Console.WriteLine("Processing completed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to simulate a hand‑drawn brush effect on a PNG by defining a custom convolution matrix at runtime.
 * 2. When you want to experiment with edge‑enhancement or blur filters by entering arbitrary kernel values without pre‑built presets.
 * 3. When building an interactive image‑editing tool that lets users specify odd‑sized kernels to achieve unique visual styles.
 * 4. When processing scientific or medical PNG images that require a user‑defined filter for noise reduction or feature extraction.
 * 5. When automating batch processing of PNG files where each image receives a different custom kernel based on user input or external data.
 */
