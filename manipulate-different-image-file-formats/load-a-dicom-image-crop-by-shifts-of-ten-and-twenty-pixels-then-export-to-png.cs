using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\sample.dicom";
        string outputPath = @"C:\Temp\sample.Crop.png";

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
                // Cast to DicomImage to access DICOM-specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Crop the image: left/right shift 10 pixels, top/bottom shift 20 pixels
                dicomImage.Crop(10, 10, 20, 20);

                // Save the cropped image as PNG
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
 * 1. When a medical imaging application needs to extract a region of interest from a DICOM scan and store it as a PNG for web display.
 * 2. When a radiology workflow requires removing border artifacts by cropping 10‑pixel sides and 20‑pixel top/bottom from DICOM files before archiving them as PNG thumbnails.
 * 3. When a healthcare data integration service converts DICOM images to PNG after applying a fixed pixel offset crop to fit a standardized report template.
 * 4. When a diagnostic software automates batch processing of DICOM scans, cropping each image by 10 px horizontally and 20 px vertically and saving the result as PNG for downstream AI analysis.
 * 5. When a hospital IT system needs to verify that a DICOM file exists, create the output folder, crop the image, and export it to PNG for inclusion in patient electronic health records.
 */