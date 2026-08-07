using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.psd";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Apply Gaussian blur to the raster image
                RasterImage raster = image as RasterImage;
                if (raster != null)
                {
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                }

                // Configure PNG export options with text rendering hint
                PngOptions pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions();
                pngOptions.VectorRasterizationOptions.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;

                // Save the processed image as PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When a web developer needs to create a softened preview of a Photoshop PSD file for faster page loading, they can apply a Gaussian blur and export it as a PNG with optimized text rendering.
 * 2. When an e‑learning platform wants to generate low‑resolution PNG thumbnails of high‑resolution PSD slides while preserving crisp vector text, they can use this code to blur the background and set the TextRenderingHint to SingleBitPerPixel.
 * 3. When a digital asset management system must automatically produce watermarked PNG copies of PSD artwork with a subtle blur effect to protect intellectual property, the code provides the necessary image filtering and export options.
 * 4. When a mobile app needs to display a blurred background derived from a PSD design and ensure that any overlaid text renders sharply in the PNG output, developers can employ this routine.
 * 5. When a batch‑processing tool is required to convert multiple PSD files into PNG format with a uniform Gaussian blur and consistent text rendering settings for print‑ready PDFs, this snippet handles the conversion efficiently.
 */