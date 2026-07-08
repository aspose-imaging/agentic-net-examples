using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

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
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                raster.Save(outputPath, options);
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
 * 1. When a developer wants to enhance the vertical edges of a landscape PNG photograph to improve visual contrast before publishing on a website.
 * 2. When an image‑processing pipeline needs to apply a Sobel‑like vertical edge detection filter to PNG files using C# and Aspose.Imaging for automated quality checks.
 * 3. When a GIS or mapping application must highlight terrain features by emphasizing vertical edges in raster images during data preprocessing.
 * 4. When a photo‑editing tool integrates a custom convolution kernel to create a stylized edge‑enhanced version of user‑uploaded PNG images in a .NET environment.
 * 5. When a batch‑processing script has to generate edge‑detected PNG thumbnails for a digital asset management system using Aspose.Imaging’s ConvolutionFilterOptions.
 */