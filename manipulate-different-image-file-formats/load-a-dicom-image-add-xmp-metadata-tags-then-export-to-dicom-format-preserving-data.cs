// HOW-TO: Add XMP Metadata to DICOM Image and Save with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var options = new DicomOptions();

                var xmp = new Aspose.Imaging.Xmp.XmpPacketWrapper();
                options.XmpData = xmp;

                image.Save(outputPath, options);
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
 * 1. When a medical imaging system needs to embed custom XMP tags into DICOM files without altering pixel data.
 * 2. When a radiology workflow requires adding provenance information to DICOM scans before archiving.
 * 3. When a developer must programmatically insert metadata into DICOM images for compliance with PACS standards.
 * 4. When an application converts incoming DICOM files to include XMP metadata for downstream analytics.
 * 5. When a healthcare app needs to preserve original DICOM data while augmenting the file with additional metadata.
 */
