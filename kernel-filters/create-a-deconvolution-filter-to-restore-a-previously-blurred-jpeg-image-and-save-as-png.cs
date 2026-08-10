// HOW-TO: Restore Blurred JPEG Image Using Gauss Wiener Deconvolution in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\blurred.jpg";
            string outputPath = @"C:\Images\restored.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the blurred JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Create Gauss-Wiener deconvolution filter options (radius, sigma)
                var deconvOptions = new GaussWienerFilterOptions(5, 4.0);
                // Optional: adjust additional parameters
                deconvOptions.Brightness = 1.15; // default recommended
                deconvOptions.Snr = 0.007;       // default recommended

                // Apply the deconvolution filter to the entire image
                rasterImage.Filter(rasterImage.Bounds, deconvOptions);

                // Save the restored image as PNG
                rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When a web application needs to automatically sharpen user‑uploaded blurry JPEG photos before displaying them as high‑quality PNG thumbnails.
 * 2. When a desktop tool must batch‑process scanned documents that suffered motion blur, restoring readability and saving the results in lossless PNG format.
 * 3. When an e‑commerce platform wants to improve product images that were compressed as JPEG and appear out of focus, using a Gauss‑Wiener filter to enhance them for catalog listings.
 * 4. When a medical imaging system receives JPEG scans with slight blur and requires deconvolution to recover diagnostic details while preserving the image as PNG for further analysis.
 * 5. When a digital archivist needs to restore aged JPEG photographs with blur artifacts and store the cleaned versions as PNG files for long‑term preservation.
 */
