// HOW-TO: Convert DICOM to PNG while Preserving Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dcm";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                PngOptions options = new PngOptions();

                // Transfer metadata if available
                options.XmpData = dicom.XmpData;
                options.ExifData = dicom.ExifData;

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
 * 1. When a hospital needs to export DICOM scans as PNG files for web viewing while keeping patient and study information embedded for audit trails.
 * 2. When a research team converts medical images to PNG for machine‑learning preprocessing but must retain original EXIF/XMP tags to link results back to source data.
 * 3. When a radiology PACS integration creates thumbnail PNGs for reports and wants the images to carry the original DICOM metadata for regulatory compliance.
 * 4. When a developer builds a document management system that stores PNG copies of DICOM images and requires embedded metadata to support searchable archives.
 * 5. When a telemedicine application sends PNG snapshots of DICOM scans to mobile devices and needs the metadata to be preserved for accurate diagnosis verification.
 */
