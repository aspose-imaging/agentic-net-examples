using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.dcm";
        string outputPath = @"C:\Temp\output\image.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (unconditional)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            // Extract patient name from DICOM metadata using dynamic to avoid compile‑time binding issues
            string patientName = "Unknown";
            try
            {
                dynamic dicomInfo = dicomImage.FileInfo.DicomInfo;
                patientName = dicomInfo?.PatientName ?? "Unknown";
            }
            catch
            {
                // If metadata extraction fails, keep default name
            }

            // Sanitize patient name for file system usage
            foreach (char c in Path.GetInvalidFileNameChars())
                patientName = patientName.Replace(c.ToString(), string.Empty);

            // Build the PNG file name embedding the patient name
            string pngFileName = $"image_{patientName}.png";
            string pngFullPath = Path.Combine(Path.GetDirectoryName(outputPath), pngFileName);

            // Ensure the directory for the new file exists (unconditional)
            Directory.CreateDirectory(Path.GetDirectoryName(pngFullPath));

            // Save the image as PNG
            dicomImage.Save(pngFullPath, new PngOptions());
        }
    }
}