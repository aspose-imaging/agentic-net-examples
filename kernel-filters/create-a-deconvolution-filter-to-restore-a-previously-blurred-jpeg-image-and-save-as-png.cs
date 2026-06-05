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

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply a Gauss-Wiener deconvolution filter (radius 5, sigma 4.0)
                var filterOptions = new GaussWienerFilterOptions(5, 4.0);
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                // Save the result as PNG with default options
                var pngOptions = new PngOptions();
                rasterImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to automatically sharpen user‑uploaded JPEG photos that appear out of focus before storing them as lossless PNG files for an e‑commerce product catalog.
 * 2. When a web application must restore blurred scanned receipts saved as JPEG so that OCR engines can read them more accurately, using Aspose.Imaging’s Gauss‑Wiener deconvolution and then saving the result as PNG.
 * 3. When a security system processes low‑quality JPEG snapshots from surveillance cameras, applying a deconvolution filter in C# to improve facial details before archiving the images in PNG format.
 * 4. When a digital archiving tool converts old JPEG newspaper scans with motion blur into high‑quality PNG images for long‑term preservation and print‑ready output.
 * 5. When a medical imaging workflow receives JPEG ultrasound frames with blur, and a developer uses the Gauss‑Wiener filter to enhance the images before saving them as PNG for further diagnostic analysis.
 */