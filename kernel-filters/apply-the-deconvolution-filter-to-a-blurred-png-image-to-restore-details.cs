using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply a Gauss‑Wiener deconvolution filter (deblurring)
                // Parameters: radius = 5, sigma = 4.0 (adjust as needed)
                var filterOptions = new GaussWienerFilterOptions(5, 4.0);
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                // Save the restored image
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
 * 1. When a developer needs to restore details in a blurred PNG photograph taken with a low‑light camera by applying a Gauss‑Wiener deconvolution filter using Aspose.Imaging for .NET.
 * 2. When an e‑commerce platform wants to automatically sharpen product PNG images that appear out of focus before publishing them on the website, using C# and the RasterImage.Filter method.
 * 3. When a medical imaging application must improve the clarity of scanned PNG slides that suffered motion blur, by loading the image with Aspose.Imaging and applying a deconvolution filter.
 * 4. When a document management system processes uploaded PNG scans and needs to enhance legibility of text by deblurring with a Gauss‑Wiener filter in a .NET service.
 * 5. When a game developer prepares PNG texture assets that were unintentionally blurred during export and wants to programmatically restore sharpness during the build pipeline using Aspose.Imaging’s deconvolution filter.
 */