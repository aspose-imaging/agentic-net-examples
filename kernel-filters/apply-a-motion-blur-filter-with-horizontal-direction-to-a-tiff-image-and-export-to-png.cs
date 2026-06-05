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
        string outputPath = @"C:\Images\sample.MotionBlur.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access the Filter method
                TiffImage tiffImage = (TiffImage)image;

                // Apply a horizontal motion blur (angle = 0 degrees)
                // Length = 10, Sigma = 1.0 (adjust as needed)
                var motionBlurOptions = new MotionWienerFilterOptions(10, 1.0, 0.0);
                tiffImage.Filter(tiffImage.Bounds, motionBlurOptions);

                // Save the result as PNG
                tiffImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to create a stylized preview of a high‑resolution TIFF scan by adding a horizontal motion blur and saving it as a lightweight PNG for web galleries.
 * 2. When an imaging pipeline must preprocess scanned documents (TIFF) to simulate camera shake in the horizontal axis before converting them to PNG for visual effects testing.
 * 3. When a batch job has to generate motion‑blurred thumbnails from large TIFF files, using Aspose.Imaging for .NET to apply a horizontal blur and output PNGs for faster loading.
 * 4. When a medical imaging application wants to anonymize patient details by obscuring them with a horizontal motion blur on TIFF X‑ray images and then export the result as PNG for reporting.
 * 5. When a developer is building a C# tool that demonstrates image‑filter capabilities, applying a horizontal motion blur to a TIFF and saving the result as PNG to showcase Aspose.Imaging filter options.
 */