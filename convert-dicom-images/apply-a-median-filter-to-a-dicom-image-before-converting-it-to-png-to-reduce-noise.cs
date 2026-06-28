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
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\sample.dicom";
            string outputPath = @"c:\temp\sample.filtered.png";

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
                // Cast to DicomImage to access DICOM-specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Apply a median filter with size 5 to the whole image
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
 * 1. When a medical imaging application needs to reduce speckle noise in a DICOM X‑ray before exporting it as a PNG for web viewing, the median filter can be applied as shown.
 * 2. When a radiology workflow requires converting noisy CT scan slices to PNG thumbnails for PACS integration, developers can load the DICOM, filter it, and save the cleaned PNG.
 * 3. When a research tool must preprocess MRI DICOM files to improve visual clarity before performing image analysis in a C# environment, applying a median filter prior to PNG conversion is essential.
 * 4. When a hospital’s reporting system needs to generate printable PNG reports from DICOM ultrasound images while minimizing grainy artifacts, the code demonstrates the required steps.
 * 5. When a healthcare mobile app needs to display patient DICOM images with reduced noise on low‑resolution screens, developers can use this median‑filter‑and‑save routine in .NET.
 */