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
                // Cast to RasterImage to apply filters
                var raster = (RasterImage)image;

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
 * 1. When a medical imaging application needs to anonymize patient scans by blurring sensitive details in a DICOM file before sharing it as a lightweight GIF for quick review.
 * 2. When a radiology workflow requires converting high‑resolution DICOM images to GIFs with a Gaussian blur effect to reduce file size for web‑based case studies.
 * 3. When a healthcare data pipeline processes DICOM X‑ray images, applies a 5‑pixel radius Gaussian blur to smooth noise, and saves the result as a GIF for inclusion in electronic health records.
 * 4. When a C# developer builds a diagnostic reporting tool that loads DICOM scans, softens edges using a Gaussian blur filter, and exports the visual as a GIF for easy embedding in PDFs.
 * 5. When a telemedicine platform needs to automatically load DICOM images, apply a blur to protect patient privacy, and deliver the processed image as a GIF to remote clinicians using Aspose.Imaging for .NET.
 */