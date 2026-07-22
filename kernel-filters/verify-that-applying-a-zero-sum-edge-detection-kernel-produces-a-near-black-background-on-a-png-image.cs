using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
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
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, convOptions);

                var pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When a developer wants to apply a zero‑sum edge‑detection convolution kernel to a PNG image in a C# application to highlight edges and verify that the background becomes near‑black.
 * 2. When building an automated image preprocessing pipeline that needs to load a PNG, run a 3×3 Laplacian filter using Aspose.Imaging, and save the result for further computer‑vision analysis.
 * 3. When creating a diagnostic tool that checks whether a custom convolution filter correctly suppresses uniform areas, producing a dark background on input PNG files.
 * 4. When integrating Aspose.Imaging into a .NET service that must convert raw PNG assets into edge‑enhanced versions before storing them in a content management system.
 * 5. When testing image‑processing code in unit tests to ensure that applying a zero‑sum kernel yields the expected near‑black background on sample PNG images.
 */