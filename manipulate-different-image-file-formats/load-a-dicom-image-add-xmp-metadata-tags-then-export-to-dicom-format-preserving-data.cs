using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dcm";
        string outputPath = "output.dcm";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                // Create XMP packet and add DICOM metadata
                var xmpPacket = new Aspose.Imaging.Xmp.XmpPacketWrapper();
                var dicomPackage = new Aspose.Imaging.Xmp.Schemas.Dicom.DicomPackage();
                dicomPackage.SetPatientName("John Doe");
                dicomPackage.SetPatientId("12345");
                dicomPackage.SetStudyDescription("Sample Study");
                xmpPacket.AddPackage(dicomPackage);

                // Assign XMP data to the image
                dicomImage.XmpData = xmpPacket;

                // Save with XMP metadata preserved
                var options = new DicomOptions { XmpData = xmpPacket };
                dicomImage.Save(outputPath, options);
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
 * 1. When a medical imaging application must embed patient details such as name and ID into a DICOM file without altering the pixel data, a developer can use this code to add XMP metadata and save the updated DICOM.
 * 2. When a hospital PACS integration needs to attach study descriptions to existing DICOM scans for improved searchability, the code shows how to create an XMP packet and preserve it during export.
 * 3. When a research project requires programmatically inserting or updating custom metadata in DICOM datasets while keeping the image format unchanged, this snippet provides the C# approach with Aspose.Imaging.
 * 4. When a radiology workflow automation tool has to generate new DICOM files from templates and include standardized metadata tags for compliance reporting, the example demonstrates loading, modifying XMP data, and saving with DicomOptions.
 * 5. When a cloud‑based health‑tech service wants to batch‑process DICOM images to add consistent patient identifiers before uploading to a secure server, this code offers a reliable way to add XMP metadata in .NET.
 */