using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

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

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM-specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Define the cropping rectangle (0,0,200,200)
                Rectangle cropArea = new Rectangle(0, 0, 200, 200);

                // Perform the crop operation
                dicomImage.Crop(cropArea);

                // Save the cropped image as GIF
                dicomImage.Save(outputPath, new GifOptions());
            }
        }
        catch (Exception ex)
        {
            // Output any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a radiology application needs to extract a 200 × 200 pixel region from a DICOM scan and embed it as a GIF thumbnail for a web‑based patient portal.
 * 2. When a healthcare data pipeline must convert a specific area of a DICOM image to a lightweight GIF format for inclusion in electronic health record (EHR) reports.
 * 3. When a medical research tool requires cropping the top‑left corner of a DICOM image to focus on a lesion and then save it as a GIF for quick visual inspection in a C# WinForms UI.
 * 4. When a telemedicine platform wants to generate a small GIF preview of a DICOM X‑ray by cropping a 200‑pixel square and sending it over low‑bandwidth connections.
 * 5. When a diagnostic imaging workflow automates the extraction of a region of interest from DICOM files and stores the result as a GIF for integration with non‑medical image viewers.
 */