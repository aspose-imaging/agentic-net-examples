using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.dcm";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;

                // Apply Bradley adaptive thresholding (brightnessDifference = 5, windowSize = 10)
                dicomImage.BinarizeBradley(5, 10);

                // Rotate the image 180 degrees
                dicomImage.RotateFlip(RotateFlipType.Rotate180FlipNone);

                // Save the processed image as BMP
                var bmpOptions = new BmpOptions();
                dicomImage.Save(outputPath, bmpOptions);
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
 * 1. When a radiology web portal needs to create high‑contrast BMP thumbnails from DICOM X‑ray scans, the code loads the DICOM, applies Bradley adaptive thresholding, rotates 180°, and saves the result as BMP.
 * 2. When a medical research project must preprocess MRI slices by binarizing them with a Bradley threshold and normalizing orientation before feeding them into a machine‑learning model, this C# snippet performs the required steps.
 * 3. When a hospital PACS integration has to export DICOM ultrasound frames as BMP files for legacy reporting tools that only accept BMP, the code loads the DICOM, enhances contrast, rotates the image, and writes a BMP output.
 * 4. When a desktop application generates printable BMP copies of DICOM dental images, applying adaptive thresholding and a 180‑degree rotation ensures the printed image matches the original scan’s orientation.
 * 5. When an AI‑driven diagnostic system needs binary BMP versions of DICOM CT images with a consistent upside‑down orientation for downstream analysis, this example provides the complete processing pipeline.
 */

/*
 * Real-World Use Cases:
 * 1. When a radiology application must convert a DICOM scan into a high‑contrast BMP for legacy PACS viewers, applying Bradley adaptive thresholding and rotating the image for correct orientation.
 * 2. When a medical research tool needs to preprocess CT images by binarizing them, flipping them 180° to match patient positioning, and exporting to BMP for analysis in raster‑only image‑processing libraries.
 * 3. When a hospital document management system automates the creation of BMP thumbnails from DICOM files, using adaptive thresholding and a 180° rotation to ensure consistent display across devices.
 * 4. When a telemedicine platform prepares DICOM ultrasound frames for web‑based reporting by applying Bradley thresholding, rotating the image, and saving as BMP to embed in HTML pages.
 * 5. When a quality‑control script for a diagnostic imaging device validates image orientation and contrast by binarizing DICOM images, rotating them 180°, and saving as BMP for visual inspection by technicians.
 */