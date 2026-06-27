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
            string inputPath = @"C:\Images\blurred.png";
            string outputPath = @"C:\Images\restored.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Create Gauss-Wiener deconvolution filter options (radius, sigma)
                var deconvOptions = new GaussWienerFilterOptions(5, 4.0);
                // Optional: adjust additional properties if needed
                // deconvOptions.Brightness = 1.15;
                // deconvOptions.Snr = 0.007;

                // Apply the filter to the whole image
                rasterImage.Filter(rasterImage.Bounds, deconvOptions);

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
 * 1. When a developer needs to improve the readability of scanned documents saved as PNG that suffer from motion blur, this code can deblur and enhance the text.
 * 2. When an e‑commerce platform wants to automatically sharpen out‑of‑focus product photos uploaded as PNG files, the deconvolution filter restores visual details before publishing.
 * 3. When a medical imaging application receives blurred PNG scans of tissue samples, the code can recover fine structures for better diagnostic analysis.
 * 4. When a security system processes low‑light PNG footage blurred by camera shake, applying the Gauss‑Wiener filter helps reveal facial features for identification.
 * 5. When a digital archivist restores old PNG artwork that has become hazy over time, this routine can recover original colors and edges for preservation.
 */