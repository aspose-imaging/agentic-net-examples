// HOW-TO: Create Custom Convolution Filter with User-Defined Kernel in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

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

            Console.WriteLine("Enter kernel size (odd integer):");
            if (!int.TryParse(Console.ReadLine(), out int size) || size <= 0 || size % 2 == 0)
            {
                Console.Error.WriteLine("Invalid kernel size.");
                return;
            }

            double[,] kernel = new double[size, size];
            Console.WriteLine($"Enter {size * size} kernel values row by row, separated by spaces:");
            for (int i = 0; i < size; i++)
            {
                string line = Console.ReadLine();
                if (line == null)
                {
                    Console.Error.WriteLine("Insufficient input.");
                    return;
                }
                string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != size)
                {
                    Console.Error.WriteLine($"Expected {size} values for row {i + 1}.");
                    return;
                }
                for (int j = 0; j < size; j++)
                {
                    if (!double.TryParse(parts[j], out double value))
                    {
                        Console.Error.WriteLine($"Invalid number at row {i + 1}, column {j + 1}.");
                        return;
                    }
                    kernel[i, j] = value;
                }
            }

            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var filterOptions = new ConvolutionFilterOptions(kernel);
                image.Filter(image.Bounds, filterOptions);
                image.Save(outputPath, new PngOptions());
            }

            Console.WriteLine("Filtering completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a desktop application needs to let users fine‑tune a convolution filter by entering their own kernel values for PNG images.
 * 2. When you want to apply a custom blur, sharpen, or edge‑detection effect to an image using Aspose.Imaging based on runtime user input.
 * 3. When a photo‑editing tool must validate odd‑sized kernels and reject invalid entries before processing the image.
 * 4. When you need to dynamically generate a filter matrix from a UI form and apply it to a raster image without hard‑coding the coefficients.
 * 5. When an automated batch process requires reading a user‑specified kernel from the console to produce a filtered output PNG file.
 */
