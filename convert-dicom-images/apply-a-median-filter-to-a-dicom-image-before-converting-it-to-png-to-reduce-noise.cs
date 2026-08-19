// HOW-TO: Apply Median Filter to DICOM and Convert to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "sample.dicom";
            string outputPath = "sample.MedianFiltered.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;

                // Apply a median filter with size 5 to the entire image
                dicomImage.Filter(dicomImage.Bounds, new MedianFilterOptions(5));

                // Save the filtered image as PNG
                dicomImage.Save(outputPath, new PngOptions());
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
 * 1. When a radiology application needs to reduce speckle noise in DICOM scans before displaying them as PNG thumbnails for web viewers.
 * 2. When a healthcare data pipeline must preprocess DICOM images with a median filter to improve visual quality before archiving them as lossless PNG files.
 * 3. When a C# program has to convert noisy DICOM ultrasound frames to PNG for integration with a machine‑learning model that expects clean pixel data.
 * 4. When a medical imaging system requires batch processing of DICOM files, applying a 5‑pixel median filter and saving the results as PNG for patient reports.
 * 5. When a developer wants to use Aspose.Imaging to denoise DICOM images and export them to PNG for use in cross‑platform mobile health apps.
 */
