using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.svg";

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

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 500x500 pixels
                image.Resize(500, 500);

                // Apply a median filter (kernel size 5) to the entire image
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                // Prepare SVG save options with rasterization settings
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                // Save the processed image as SVG
                image.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to convert legacy BMP assets into scalable SVG graphics for responsive web design while ensuring the images are uniformly sized at 500 × 500 pixels and noise‑reduced with a median filter, this code provides a ready‑to‑use solution.
 * 2. When an e‑commerce platform must generate thumbnail previews from high‑resolution BMP product photos, resize them to a fixed 500 × 500 size, apply a median filter to smooth artifacts, and store the result as SVG for lightweight vector rendering, the snippet handles the entire pipeline.
 * 3. When a desktop application imports scanned BMP documents, normalizes their dimensions, removes speckle noise using a 5‑pixel median filter, and exports them as SVG files for further editing in vector‑based tools, this example demonstrates the required steps.
 * 4. When a game developer wants to preprocess BMP sprite sheets by resizing each sprite to 500 × 500 pixels, applying a median filter to improve visual quality, and converting them to SVG for resolution‑independent UI elements, the code accomplishes that workflow.
 * 5. When an automated build script must batch‑process BMP icons, enforce a consistent 500 × 500 size, clean up noise with a median filter, and output SVG files for inclusion in cross‑platform .NET applications, this program provides the necessary implementation.
 */