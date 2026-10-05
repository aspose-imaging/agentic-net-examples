// HOW-TO: Convert DICOM File to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

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
 * 1. When a medical imaging application needs to generate viewable PNG thumbnails from DICOM scans for web display.
 * 2. When a radiology workflow requires batch conversion of DICOM images to PNG for integration with non‑medical image viewers.
 * 3. When a research project must extract PNG snapshots from DICOM files to include in publications or presentations.
 * 4. When a hospital IT system needs to archive DICOM studies as lossless PNG files for long‑term storage or backup.
 * 5. When a developer builds a command‑line utility to automate conversion of DICOM images to PNG as part of a CI/CD pipeline.
 */
