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

                double[,] kernel = new double[3, 3]
                {
                    { -1, -1, -1 },
                    { -1, 8, -1 },
                    { -1, -1, -1 }
                };

                var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                raster.Filter(raster.Bounds, convOptions);

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
 * 1. When a developer needs to automatically detect edges in a PNG photograph to highlight object boundaries for a computer‑vision preprocessing step.
 * 2. When a C# application must generate a custom 3×3 convolution kernel at runtime to apply edge detection on scanned documents before OCR processing.
 * 3. When a web service processes user‑uploaded PNG images and wants to enhance visual contrast by applying a Laplacian edge detection filter using Aspose.Imaging.
 * 4. When a desktop utility converts PNG screenshots into stylized line‑art by applying a dynamically created convolution kernel for edge extraction.
 * 5. When an automated testing framework validates image‑processing pipelines by programmatically applying a 3×3 edge detection filter to PNG assets and comparing the results.
 */