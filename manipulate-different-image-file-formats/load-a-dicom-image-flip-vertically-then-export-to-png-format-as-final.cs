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
        string inputPath = @"c:\temp\sample.dcm";
        string outputPath = @"c:\temp\sample_flipped.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image, flip vertically, and save as PNG
            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                // Flip vertically (no rotation, vertical flip)
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);

                // Save the transformed image to PNG format
                image.Save(outputPath, new PngOptions());
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
 * 1. When a medical imaging application needs to display a DICOM X‑ray that was captured upside‑down, a developer can load the .dcm file, flip it vertically, and save it as a PNG for web viewing.
 * 2. When integrating radiology data into a patient portal, a programmer can convert DICOM scans to PNG thumbnails after applying a vertical flip to match the orientation of other images.
 * 3. When preparing DICOM images for machine‑learning preprocessing, a developer may need to normalize orientation by flipping the image vertically and exporting it to PNG for the training pipeline.
 * 4. When generating printable reports that require standard image formats, a developer can use Aspose.Imaging to load a DICOM file, perform a vertical flip, and save the result as a PNG for inclusion in PDFs.
 * 5. When troubleshooting mismatched image orientation in a PACS system, a developer can quickly flip the DICOM image vertically in C# and export it to PNG to verify the correction visually.
 */