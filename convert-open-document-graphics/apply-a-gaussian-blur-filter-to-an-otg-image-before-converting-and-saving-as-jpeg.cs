// HOW-TO: Apply Gaussian Blur to OTG Image and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample_blurred.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filter
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with size 5 and sigma 4.0 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Prepare JPEG save options with vector rasterization for OTG
                var jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = new OtgRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                // Save the processed image as JPEG
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to soften the details of a vector‑based OTG graphic before delivering it as a compressed JPEG for web thumbnails.
 * 2. When you want to preprocess an OTG illustration with a Gaussian blur to reduce noise prior to printing or publishing as a raster JPEG.
 * 3. When an application must convert proprietary OTG drawings to JPEG while applying a blur effect for privacy or artistic styling.
 * 4. When you are building a batch pipeline that loads OTG files, applies a uniform blur, and outputs JPEGs for mobile devices.
 * 5. When you need to programmatically rasterize an OTG page, blur the entire image, and save it with JPEG options in a .NET service.
 */
