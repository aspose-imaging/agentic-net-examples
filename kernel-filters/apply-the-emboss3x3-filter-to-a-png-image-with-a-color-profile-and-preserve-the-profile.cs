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

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                PngOptions options = new PngOptions
                {
                    KeepMetadata = true
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
 * 1. When a developer needs to generate stylized product thumbnails for an e‑commerce site and wants to keep the original PNG color profile for accurate brand colors.
 * 2. When a desktop publishing application must apply an emboss effect to user‑uploaded PNG graphics while preserving embedded ICC profiles for consistent print output.
 * 3. When an automated image‑processing pipeline adds a 3‑x‑3 emboss filter to PNG assets before they are displayed in a mobile app, ensuring the profile remains intact for device‑specific color rendering.
 * 4. When a photo‑editing tool offers a one‑click “emboss” filter for PNG files and must retain metadata such as EXIF and color space information.
 * 5. When a batch conversion utility processes a folder of PNG images, applying the Emboss3x3 convolution filter and saving them with their original color profiles for later use in digital signage.
 */