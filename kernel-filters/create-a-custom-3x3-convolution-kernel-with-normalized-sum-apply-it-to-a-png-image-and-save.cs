using System;
using System.IO;
using Aspose.Imaging;

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

                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 0);

                raster.Filter(raster.Bounds, filterOptions);

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
 * 1. When a developer wants to enhance the sharpness of a PNG photograph by applying a custom 3x3 convolution kernel with normalized sum before saving the result.
 * 2. When a C# application needs to perform edge‑enhancement on scanned documents in PNG format using Aspose.Imaging’s ConvolutionFilterOptions.
 * 3. When an image‑processing pipeline requires a lightweight, on‑the‑fly filter to improve visual clarity of PNG icons without using external libraries.
 * 4. When a software tool must automatically adjust the contrast of PNG screenshots by applying a normalized convolution matrix during batch processing.
 * 5. When a developer is building a .NET service that validates image quality by sharpening PNG assets with a custom kernel and then stores the processed files.
 */