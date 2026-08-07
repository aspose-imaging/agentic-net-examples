using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\sample.dicom";
            string outputPath = @"C:\temp\sample.Bradley15.bmp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM-specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Apply Bradley adaptive thresholding with window size 15
                // Brightness difference set to 5.0 (typical default)
                dicomImage.BinarizeBradley(5.0, 15);

                // Save the processed image as BMP
                dicomImage.Save(outputPath, new BmpOptions());
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging application needs to convert a DICOM radiograph to a high‑contrast black‑and‑white BMP for integration with legacy PACS viewers, developers can load the DICOM, apply Bradley adaptive threshold with a window size of 15, and save the result as BMP.
 * 2. When a research project requires preprocessing DICOM scans to extract binary features for machine‑learning models, the code can binarize the image using Bradley thresholding and export it to BMP for easy loading into training pipelines.
 * 3. When a hospital’s document‑management system must archive diagnostic images as universally readable BMP files while preserving edge details, developers can use this snippet to load the DICOM, apply a 15‑pixel window Bradley threshold, and save the processed image.
 * 4. When a telemedicine platform needs to generate thumbnail previews of DICOM files that highlight anatomical structures, the code can perform adaptive binarization with a window size of 15 and output a BMP thumbnail for fast web delivery.
 * 5. When a quality‑control tool for radiology equipment must compare raw DICOM output against a binary reference image, developers can employ this routine to apply Bradley adaptive thresholding with a 15‑pixel window and export the result to BMP for pixel‑by‑pixel analysis.
 */