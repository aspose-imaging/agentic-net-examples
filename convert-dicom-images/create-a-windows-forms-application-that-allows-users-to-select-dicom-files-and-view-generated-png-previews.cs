// HOW-TO: Convert DICOM File to PNG Preview Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dcm";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Image.Load(inputPath))
            {
                image.Save(outputPath, new PngOptions());
            }

            Console.WriteLine($"PNG preview saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a radiology application needs to display a quick thumbnail of a DICOM scan in a .NET Windows Forms UI.
 * 2. When a healthcare data pipeline must generate PNG snapshots of DICOM images for inclusion in patient reports.
 * 3. When a developer wants to convert DICOM files to web‑friendly PNG format for browser preview without installing additional imaging libraries.
 * 4. When an automated testing suite requires extracting visual samples from DICOM datasets to compare against expected PNG results.
 * 5. When a medical imaging archive needs to create low‑resolution PNG previews for fast searching and cataloging of large DICOM collections.
 */
