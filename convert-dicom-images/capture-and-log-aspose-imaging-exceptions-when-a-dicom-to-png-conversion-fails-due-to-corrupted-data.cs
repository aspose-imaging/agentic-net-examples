// HOW-TO: How to Convert DICOM to PNG and Log Errors in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.dcm";
            string outputPath = "Output\\sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                PngOptions options = new PngOptions();
                options.Source = new FileCreateSource(outputPath, false);
                dicom.Save(outputPath, options);
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
 * 1. When a medical imaging application needs to convert patient DICOM scans to PNG thumbnails while capturing any corruption errors for audit logs.
 * 2. When a hospital’s PACS integration script must batch‑process DICOM files into web‑friendly PNGs and record failures without crashing the service.
 * 3. When a diagnostic tool requires safe conversion of DICOM images to PNG for UI display and wants to log exception messages for corrupted files.
 * 4. When a data migration project moves legacy DICOM archives to PNG format and needs to capture and report conversion errors caused by damaged data.
 * 5. When a C# backend service generates PNG previews from uploaded DICOM files and must handle and log any read/write exceptions to maintain reliability.
 */
