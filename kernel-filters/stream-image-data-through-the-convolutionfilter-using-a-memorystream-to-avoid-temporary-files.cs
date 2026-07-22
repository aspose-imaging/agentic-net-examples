using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/output.png";

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
            // Read the input file into a memory stream (no temporary files)
            byte[] imageBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream memoryStream = new MemoryStream(imageBytes))
            {
                // Load image from the memory stream
                using (Image image = Image.Load(memoryStream))
                {
                    // Cast to RasterImage for filtering
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply a Gaussian blur convolution filter to the entire image
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                    // Save the filtered image to the output path as PNG
                    rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When a web service needs to apply a Gaussian blur to user‑uploaded PNG images on the fly without writing intermediate files to disk.
 * 2. When a desktop application processes scanned documents in memory to enhance readability by blurring noise before saving the result as a PNG.
 * 3. When an automated batch job runs in a cloud container that must filter large image assets using a convolution filter while minimizing I/O overhead.
 * 4. When a mobile backend API receives image bytes, applies a blur effect using Aspose.Imaging’s RasterImage.Filter, and returns the processed PNG directly to the client.
 * 5. When a CI/CD pipeline validates image processing steps by loading test images into a MemoryStream, applying a Gaussian blur, and saving the output for visual regression testing.
 */