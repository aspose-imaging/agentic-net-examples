// HOW-TO: Apply Gaussian Blur to DICOM and Save as GIF in C# (Aspose.Imaging for .NET)
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
            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur filter to the whole image
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image as GIF with default options
                raster.Save(outputPath, new GifOptions());
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
 * 1. When a medical imaging application needs to anonymize patient details by blurring sensitive regions of a DICOM scan before sharing it as a lightweight GIF for quick review.
 * 2. When a radiology web portal wants to generate preview thumbnails with softened edges from DICOM files to improve visual comfort for clinicians.
 * 3. When a healthcare research tool requires converting high‑resolution DICOM images into animated GIFs after applying a Gaussian blur to reduce noise for presentation slides.
 * 4. When a diagnostic software needs to preprocess DICOM images with a blur filter to smooth artifacts before exporting them to a GIF format for mobile device display.
 * 5. When a telemedicine system must automatically blur patient identifiers in DICOM images and deliver the result as a GIF to comply with privacy regulations.
 */
