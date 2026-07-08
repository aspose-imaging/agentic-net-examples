using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.dicom";
        string outputPath = @"C:\temp\sample.Crop.png";

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
                // Cast to DicomImage for DICOM-specific operations
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
 * 1. When a medical imaging application needs to extract a region of interest from a DICOM scan and store it as a lightweight PNG for web display.
 * 2. When a radiology workflow requires removing border artifacts by cropping 10‑pixel sides and 20‑pixel top/bottom from each DICOM file before archiving.
 * 3. When a healthcare data integration service must convert DICOM images to PNG thumbnails while adjusting the frame size with precise pixel offsets.
 * 4. When a diagnostic AI model expects uniformly sized PNG inputs, developers can load the original DICOM, crop it by 10 and 20 pixels, and save the result for model ingestion.
 * 5. When a hospital’s reporting tool needs to embed a cropped snapshot of a DICOM study into a PDF, the code can perform the crop and export to PNG for easy embedding.
 */