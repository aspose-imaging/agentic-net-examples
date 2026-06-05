using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.tif";
        string outputPath = @"C:\Images\sample_blur.jpg";

        // Ensure any runtime exception is reported without crashing
        try
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access the Filter method
                TiffImage tiffImage = (TiffImage)image;

                // Apply a motion blur (motion wiener) filter with a 45 degree angle
                // Parameters: length (size) = 10, smooth = 1.0, angle = 45.0 degrees
                var motionOptions = new MotionWienerFilterOptions(10, 1.0, 45.0);
                tiffImage.Filter(tiffImage.Bounds, motionOptions);

                // Save the processed image as JPEG
                tiffImage.Save(outputPath, new JpegOptions());
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
 * 1. When a developer needs to convert a high‑resolution TIFF scan of a document into a smaller JPEG for web preview while adding a 45° motion blur to hide sensitive details.
 * 2. When an imaging pipeline must apply a directional motion‑blur effect to satellite TIFF imagery before exporting to JPEG for faster loading in a GIS viewer.
 * 3. When a photo‑editing application wants to programmatically add a 45‑degree motion blur to a TIFF‑based product photo and save it as a JPEG for e‑commerce catalogs.
 * 4. When a batch‑processing script has to prepare archival TIFF files for machine‑learning training by blurring motion artifacts and converting them to JPEG format.
 * 5. When a developer is building a C# service that receives TIFF uploads, applies a motion‑wiener filter at a 45° angle to simulate camera shake, and returns the result as a JPEG image.
 */