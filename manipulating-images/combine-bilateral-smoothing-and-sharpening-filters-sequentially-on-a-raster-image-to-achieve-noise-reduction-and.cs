using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.png";
        string outputPath = @"c:\temp\sample.BilateralSharpen.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply bilateral smoothing filter (kernel size 5)
                rasterImage.Filter(rasterImage.Bounds, new BilateralSmoothingFilterOptions(5));

                // Apply sharpen filter (kernel size 5, sigma 4.0)
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the processed image
                rasterImage.Save(outputPath);
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
 * 1. When a developer needs to clean up noisy PNG screenshots while preserving edges before embedding them in a web page, they can apply bilateral smoothing followed by sharpening using Aspose.Imaging for .NET.
 * 2. When processing scanned JPEG documents that contain grainy background, the code can reduce noise and enhance text clarity by sequentially applying a bilateral filter and a sharpen filter.
 * 3. When preparing product photos in a C# desktop application for an e‑commerce catalog, the developer can use this routine to smooth color variations and then sharpen details to make the images look crisp.
 * 4. When building an automated image‑processing pipeline that receives raw BMP files from a camera, the code helps to denoise the frames and improve edge definition before saving the results.
 * 5. When integrating image enhancement into a .NET service that generates thumbnails for user‑uploaded images, applying bilateral smoothing and sharpening ensures the thumbnails are both low‑noise and visually sharp.
 */