using System;
using System.IO;

class Program
{
    static void Main(string[] args)
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

            // Load the image and cast to RasterImage
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                // Store original dimensions
                int originalWidth = raster.Width;
                int originalHeight = raster.Height;

                // Apply a convolution filter (Gaussian blur in this example)
                raster.Filter(
                    raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Verify that dimensions have not changed
                if (raster.Width == originalWidth && raster.Height == originalHeight)
                {
                    Console.WriteLine("Dimensions unchanged after filter.");
                }
                else
                {
                    Console.WriteLine($"Dimensions changed: before {originalWidth}x{originalHeight}, after {raster.Width}x{raster.Height}");
                }

                // Save the processed image
                raster.Save(outputPath);
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
 * 1. When a C# developer needs to apply a Gaussian blur to a PNG image while guaranteeing that the original width and height remain unchanged for downstream layout calculations.
 * 2. When an image‑processing pipeline must validate that applying any convolution filter (e.g., sharpening, edge detection) does not alter the raster dimensions before saving the result to disk.
 * 3. When a .NET application processes user‑uploaded photos and must ensure the output file preserves the original resolution so that UI components display it correctly.
 * 4. When a batch job converts images to a different format (e.g., PNG to JPEG) and applies filters, it needs to confirm that the filter operation does not resize the image, avoiding layout breaks.
 * 5. When debugging an Aspose.Imaging filter implementation, a developer wants to log a message if the filter unexpectedly changes the image size, helping to catch bugs early.
 */