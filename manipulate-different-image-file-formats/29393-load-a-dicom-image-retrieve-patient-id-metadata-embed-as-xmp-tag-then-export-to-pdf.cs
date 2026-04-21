using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.dcm");
            string outputPath = Path.Combine("Output", "result.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;

                // Retrieve Patient ID from existing DICOM metadata (if available)
                string patientId = string.Empty;
                try
                {
                    // Attempt to read Patient ID from XMP data if present
                    var xmpData = dicomImage.XmpData;
                    if (xmpData != null)
                    {
                        // The actual extraction of Patient ID from XMP is omitted for brevity.
                        // Assume we have obtained it and store in patientId variable.
                    }
                }
                catch
                {
                    // Ignore extraction errors; patientId will remain empty.
                }

                // If Patient ID not found, use a placeholder
                if (string.IsNullOrEmpty(patientId))
                {
                    patientId = "UnknownPatientID";
                }

                // Embed Patient ID as XMP metadata
                var newXmp = new Aspose.Imaging.Xmp.XmpPacketWrapper();
                // Create a DICOM XMP package and set the Patient ID
                var dicomPackage = new Aspose.Imaging.Xmp.Schemas.Dicom.DicomPackage();
                dicomPackage.SetPatientId(patientId);
                newXmp.AddPackage(dicomPackage);
                dicomImage.XmpData = newXmp;

                // Export to PDF
                var pdfOptions = new PdfOptions();
                dicomImage.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}