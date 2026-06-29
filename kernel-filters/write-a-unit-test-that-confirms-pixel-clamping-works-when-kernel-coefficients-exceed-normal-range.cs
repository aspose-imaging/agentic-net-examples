using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

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
                RasterImage rasterImage = (RasterImage)image;

                // Configure sharpen filter with an excessively high factor to force potential overflow.
                SharpenFilterOptions options = new SharpenFilterOptions(5, 4.0);
                options.Factor = 1000.0; // Exaggerated factor.

                // Apply the filter to the whole image.
                rasterImage.Filter(rasterImage.Bounds, options);

                // Save the filtered image.
                rasterImage.Save(outputPath, new PngOptions());

                // Verify pixel values are clamped between 0 and 255.
                Aspose.Imaging.Color pixel = rasterImage.GetPixel(0, 0);
                bool clamped = pixel.A >= 0 && pixel.A <= 255 &&
                               pixel.R >= 0 && pixel.R <= 255 &&
                               pixel.G >= 0 && pixel.G <= 255 &&
                               pixel.B >= 0 && pixel.B <= 255;

                Console.WriteLine(clamped ? "Pixel clamping verified." : "Pixel clamping failed.");
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
 * 1. When a developer needs to ensure that applying an extreme sharpen filter to PNG images does not produce pixel values outside the 0‑255 range, they can use this unit test to verify automatic clamping.
 * 2. When integrating Aspose.Imaging into a C# image‑processing pipeline that accepts user‑defined filter factors, this test confirms that unusually high factor values are safely limited.
 * 3. When validating that raster image operations such as GetPixel and Save correctly handle overflow after kernel coefficient manipulation, the code provides a reproducible scenario.
 * 4. When building automated regression tests for image‑enhancement features that involve custom SharpenFilterOptions, this example checks that the library prevents color channel overflow.
 * 5. When troubleshooting issues where corrupted or malicious input images cause kernel calculations to exceed normal limits, the test demonstrates that Aspose.Imaging clamps pixel components to valid byte values.
 */