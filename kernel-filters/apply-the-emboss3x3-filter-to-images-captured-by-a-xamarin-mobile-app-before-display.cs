// HOW-TO: Apply Emboss 3x3 Filter to PNG Images in C# (Aspose.Imaging for .NET)
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
                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));
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
 * 1. When you need to give photos taken in a Xamarin app a stylized 3‑D look before showing them to users, you can load the PNG, apply the Emboss3x3 convolution filter with Aspose.Imaging, and save the result.
 * 2. When generating thumbnails for a gallery where each thumbnail should appear embossed to highlight texture, you can process the source image with the Emboss3x3 filter in C# and output a PNG.
 * 3. When building an AR preview that overlays a realistic relief effect on captured images, applying the Emboss3x3 filter to the raster image ensures the effect is applied consistently across devices.
 * 4. When converting scanned documents to a visual style that mimics raised lettering for a printing workflow, you can use Aspose.Imaging’s ConvolutionFilterOptions to emboss the PNG before saving.
 * 5. When creating a custom image‑processing pipeline that must handle missing files gracefully and automatically create output directories, the sample code demonstrates how to check file existence, apply the Emboss3x3 filter, and store the processed image.
 */
