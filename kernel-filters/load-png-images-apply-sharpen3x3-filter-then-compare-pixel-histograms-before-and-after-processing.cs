using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output_sharpened.png";

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
                // Cast to RasterImage for pixel access and filtering
                RasterImage rasterImage = (RasterImage)image;

                // Compute histogram before processing
                int[] beforeHistogram = ComputeHistogram(rasterImage);

                // Apply Sharpen 3x3 filter (default constructor)
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions());

                // Compute histogram after processing
                int[] afterHistogram = ComputeHistogram(rasterImage);

                // Save the processed image
                rasterImage.Save(outputPath);

                // Output histogram comparison
                Console.WriteLine("Histogram before sharpening:");
                PrintHistogram(beforeHistogram);

                Console.WriteLine("\nHistogram after sharpening:");
                PrintHistogram(afterHistogram);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Computes a simple grayscale histogram (256 bins) for a RasterImage
    static int[] ComputeHistogram(RasterImage raster)
    {
        int[] histogram = new int[256];
        for (int y = 0; y < raster.Height; y++)
        {
            for (int x = 0; x < raster.Width; x++)
            {
                // Get pixel color
                var color = raster.GetPixel(x, y);
                // Convert to grayscale intensity using average method
                int intensity = (color.R + color.G + color.B) / 3;
                histogram[intensity]++;
            }
        }
        return histogram;
    }

    // Prints histogram values to the console
    static void PrintHistogram(int[] histogram)
    {
        for (int i = 0; i < histogram.Length; i++)
        {
            if (histogram[i] > 0)
            {
                Console.WriteLine($"Intensity {i}: {histogram[i]}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to enhance the visual sharpness of PNG assets for a web gallery while verifying that the overall brightness distribution remains unchanged, they can load the image, apply the Sharpen3x3 filter, and compare before‑and‑after histograms.
 * 2. When an e‑commerce platform wants to automatically improve product photo clarity before uploading to a CDN and ensure the color balance is preserved, the code can process each PNG, sharpen it, and log histogram differences.
 * 3. When a medical imaging application must preprocess PNG scans to highlight fine details without altering the grayscale intensity distribution, the developer can use this routine to apply a 3×3 sharpen filter and validate the histogram.
 * 4. When a game developer prepares sprite sheets in PNG format and wants to programmatically confirm that sharpening does not introduce unexpected tonal shifts, they can run the code to compute and compare pixel histograms.
 * 5. When a batch‑processing tool for digital archives needs to sharpen scanned PNG documents and produce a report showing how the pixel intensity histogram changes, this example provides the necessary C# steps.
 */