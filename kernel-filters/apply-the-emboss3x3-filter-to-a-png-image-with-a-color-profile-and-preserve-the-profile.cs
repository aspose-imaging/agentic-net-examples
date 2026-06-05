using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                var embossKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3;
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(embossKernel);
                raster.Filter(raster.Bounds, filterOptions);

                PngOptions saveOptions = new PngOptions
                {
                    KeepMetadata = true
                };

                raster.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to add a subtle embossed effect to product photos stored as PNG files while keeping the original ICC color profile for accurate color reproduction on the web.
 * 2. When an e‑learning platform wants to generate stylized diagram thumbnails from PNG assets and must retain embedded metadata so the images remain searchable and color‑consistent across devices.
 * 3. When a digital publishing workflow requires batch processing of PNG illustrations with a 3×3 emboss convolution filter and must preserve the embedded color profile to maintain print‑ready color fidelity.
 * 4. When a mobile app creates custom stickers from user‑uploaded PNG images, applying an emboss effect and keeping the profile ensures the stickers look the same on both iOS and Android screens.
 * 5. When a content management system automatically enhances uploaded PNG logos with an emboss filter while preserving metadata and color profile to comply with brand guidelines.
 */