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
        string inputPath = "input.dcm";
        string outputPath = "output.gif";

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

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur filter to the whole image
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image as GIF with default options
                raster.Save(outputPath, new GifOptions());
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging application needs to anonymize patient scans by blurring sensitive details before sharing the images as lightweight GIF files for web review.
 * 2. When a radiology workflow requires converting DICOM X‑ray images to animated GIFs with a soft focus effect for inclusion in presentation slides or reports.
 * 3. When a telehealth platform wants to reduce bandwidth by applying a Gaussian blur to DICOM images and saving them as GIFs for fast preview on mobile devices.
 * 4. When a research tool processes large batches of DICOM scans, applying a blur filter to highlight overall anatomy and exporting the results as GIFs for quick visual inspection.
 * 5. When a diagnostic software integrates Aspose.Imaging to load DICOM files, apply a Gaussian blur for noise reduction, and output GIFs with default settings for compatibility with legacy image viewers.
 */