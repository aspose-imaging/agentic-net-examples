using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiffImage = (TiffImage)image;

                // Apply dithering (Floyd‑Steinberg, 8‑bit palette)
                tiffImage.Dither(DitheringMethod.FloydSteinbergDithering, 8);

                // Apply Gaussian blur (radius 5, sigma 4.0)
                tiffImage.Filter(tiffImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the result as PNG
                PngOptions pngOptions = new PngOptions();
                tiffImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}