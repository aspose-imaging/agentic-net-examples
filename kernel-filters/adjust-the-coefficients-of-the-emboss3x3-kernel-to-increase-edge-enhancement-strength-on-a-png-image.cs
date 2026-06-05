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

                double[,] kernel = (double[,])Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3.Clone();
                double strengthFactor = 1.5;
                int rows = kernel.GetLength(0);
                int cols = kernel.GetLength(1);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        kernel[i, j] *= strengthFactor;
                    }
                }

                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                raster.Save(outputPath, new PngOptions());
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
 * 1. When a developer wants to enhance the edges of product photos in PNG format for an e‑commerce website, they can increase the strength of the Emboss3x3 kernel using Aspose.Imaging in C#.
 * 2. When a desktop application needs to apply a stronger emboss effect to scanned documents before saving them as PNG files, the code can adjust the convolution kernel coefficients to boost edge definition.
 * 3. When a game developer wants to preprocess sprite sheets by intensifying the emboss filter to make outlines more pronounced in PNG assets, they can use this C# snippet with Aspose.Imaging.
 * 4. When an automated image‑processing pipeline must improve the visual contrast of architectural blueprints stored as PNGs by increasing edge enhancement, the adjustable kernel strength provides a simple solution.
 * 5. When a photo‑editing tool requires a customizable emboss effect that can be tuned at runtime for PNG images, developers can modify the Emboss3x3 kernel coefficients as shown to control the intensity of the effect.
 */