// HOW-TO: Batch Adjust Brightness of DICOM Images and Convert to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = @"C:\Images\Input\";
        string outputDir = @"C:\Images\Output\";

        // List of DICOM files to process
        string[] files = new string[]
        {
            "image1.dcm",
            "image2.dcm",
            "image3.dcm"
        };

        try
        {
            foreach (string fileName in files)
            {
                // Build full input path
                string inputPath = Path.Combine(inputDir, fileName);

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path (same name with .png extension)
                string outputFileName = Path.GetFileNameWithoutExtension(fileName) + ".png";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DICOM image, adjust brightness, and save as PNG
                using (Image image = Image.Load(inputPath))
                {
                    DicomImage dicomImage = (DicomImage)image;
                    dicomImage.AdjustBrightness(10);
                    dicomImage.Save(outputPath, new PngOptions());
                }
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
 * 1. When a medical imaging application needs to preprocess a set of DICOM scans by brightening them and exporting to PNG for web display.
 * 2. When a radiology workflow requires automated conversion of multiple DICOM files to a lightweight format while applying a uniform brightness correction.
 * 3. When a research project must batch‑process DICOM images to improve visibility before feeding them into a machine‑learning model that accepts PNG inputs.
 * 4. When a hospital IT system wants to generate patient‑friendly PNG snapshots from DICOM studies with a consistent brightness increase.
 * 5. When a developer builds a command‑line tool to convert and enhance DICOM files in bulk for archival or reporting purposes.
 */
