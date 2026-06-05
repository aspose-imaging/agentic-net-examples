using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.tif";
        string outputPath = "Output/result.pdf";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage for TIFF-specific operations
                TiffImage tiffImage = (TiffImage)image;

                // Apply Gaussian blur filter to the whole image
                tiffImage.Filter(tiffImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Adjust brightness (value range: -255 to 255)
                tiffImage.AdjustBrightness(50);

                // Save the processed image as PDF
                PdfOptions pdfOptions = new PdfOptions();
                tiffImage.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to preprocess scanned TIFF documents by smoothing noise with a Gaussian blur, boosting brightness, and then converting them to PDF for easier distribution.
 * 2. When an application must automatically enhance the visual quality of medical imaging TIFF files—applying blur to reduce artifacts and adjusting brightness—before saving the results as PDF for clinicians.
 * 3. When a batch‑processing job handles archival TIFF photographs, uses Gaussian blur to soften grain, brightens the images, and outputs the cleaned pages as a PDF archive.
 * 4. When a web service receives uploaded TIFF images, applies image‑filter operations such as Gaussian blur and brightness correction in C#, and returns the edited content as a PDF for downstream workflows.
 * 5. When a desktop utility converts high‑resolution TIFF scans into PDF while improving readability by applying blur and brightness adjustments using Aspose.Imaging for .NET.
 */