// HOW-TO: Apply Emboss5x5 Filter to High Resolution TIFF and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input\\highres.tif";
        string outputPath = "output\\highres.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(
                    raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5));

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

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
 * 1. When you need to add a 3‑D emboss effect to a high‑resolution TIFF scan before converting it to a web‑friendly PNG.
 * 2. When preparing architectural drawings stored as TIFF for presentation, applying an emboss filter highlights edges and then saves as PNG for faster loading.
 * 3. When automating a batch process that enhances satellite imagery TIFF files with embossing and outputs PNGs for GIS applications.
 * 4. When converting scanned documents to PNG while emphasizing texture, using Aspose.Imaging’s Emboss5x5 convolution filter in C#.
 * 5. When creating stylized thumbnails from large TIFF photos, applying an emboss effect and saving the result as a lightweight PNG.
 */
