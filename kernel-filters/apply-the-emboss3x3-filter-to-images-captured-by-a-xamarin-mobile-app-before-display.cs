// HOW-TO: Apply Emboss 3x3 Filter to JPEG Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output/output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = image as Aspose.Imaging.RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                var filterOptions = new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3);
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
 * 1. When you need to add a 3‑pixel emboss effect to photos captured in a Xamarin mobile app before displaying them to users.
 * 2. When you must process JPEG files on a server‑side C# service to create stylized thumbnails using Aspose.Imaging’s ConvolutionFilter.
 * 3. When you want to enhance raster images for an e‑commerce product gallery by applying an emboss filter with Aspose.Imaging.
 * 4. When you require automated batch processing of images in a folder, applying the Emboss3x3 convolution to each file safely.
 * 5. When you need to ensure the output directory exists and gracefully handle missing source files while applying a convolution filter in a .NET application.
 */
