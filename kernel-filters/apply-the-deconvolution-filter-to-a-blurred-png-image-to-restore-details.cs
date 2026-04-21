using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "blurred.png";
        string outputPath = "restored.png";

        // Verify that the input file exists
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

            // Configure a Gauss-Wiener deconvolution filter (radius, sigma)
            var deconvOptions = new GaussWienerFilterOptions(5, 4.0);
            // Optional: adjust additional parameters if needed
            deconvOptions.Snr = 0.007;          // default signal‑to‑noise ratio
            deconvOptions.Brightness = 1.15;    // default brightness

            // Apply the filter to the whole image
            rasterImage.Filter(rasterImage.Bounds, deconvOptions);

            // Save the restored image
            rasterImage.Save(outputPath);
        }
    }
}