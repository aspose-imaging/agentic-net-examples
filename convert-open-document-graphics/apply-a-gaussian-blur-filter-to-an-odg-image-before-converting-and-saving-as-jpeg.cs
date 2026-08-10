// HOW-TO: Apply Gaussian Blur to ODG and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\sample_blur.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the ODG image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Prepare JPEG options with rasterization settings for the ODG image
                var jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = new OdgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = odgImage.Size
                    }
                };

                // Rasterize the ODG image into a memory stream
                using (var memoryStream = new MemoryStream())
                {
                    odgImage.Save(memoryStream, jpegOptions);
                    memoryStream.Position = 0;

                    // Load the rasterized image as a RasterImage
                    using (Image rasterImageWrapper = Image.Load(memoryStream))
                    {
                        var rasterImage = (RasterImage)rasterImageWrapper;

                        // Apply Gaussian blur filter to the entire image
                        rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                        // Save the processed image as JPEG
                        rasterImage.Save(outputPath, jpegOptions);
                    }
                }
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
 * 1. When you need to soften the edges of a vector ODG diagram before embedding it in a web page as a JPEG.
 * 2. When you want to reduce visual noise in an ODG illustration prior to printing it as a compressed JPEG file.
 * 3. When an application must convert OpenDocument graphics to raster JPEGs while applying a blur effect for a background placeholder.
 * 4. When generating thumbnail previews of ODG drawings that require a subtle blur to hide details and save bandwidth.
 * 5. When automating batch processing of ODG assets to create blurred JPEG versions for UI overlays or watermarks.
 */
