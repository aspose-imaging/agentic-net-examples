// HOW-TO: Convert DICOM File to PNG Images Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input DICOM file and output folder
            string inputPath = "sample.dicom";
            string outputFolder = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output folder exists
            Directory.CreateDirectory(outputFolder);

            // Open the DICOM file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load the DICOM image from the stream
                using (DicomImage dicomImage = new DicomImage(stream))
                {
                    // Iterate through each page and save as PNG
                    foreach (var dicomPage in dicomImage.DicomPages)
                    {
                        string outputPath = Path.Combine(outputFolder, $"page_{dicomPage.Index}.png");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
                        dicomPage.Save(outputPath, new PngOptions());
                    }
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
 * 1. When a medical imaging application needs to extract each frame from a DICOM study and store them as PNG files for web preview.
 * 2. When a radiology workflow requires a command‑line utility to batch‑convert DICOM scans to portable PNG images for integration with non‑DICOM systems.
 * 3. When a developer wants to automate the creation of thumbnail PNGs from multi‑page DICOM files for reporting dashboards.
 * 4. When a hospital IT script must verify that a DICOM file exists and generate PNG outputs in a specific output folder before archiving.
 * 5. When a research project needs to read DICOM data from a stream, iterate over all pages, and save each as a lossless PNG for image analysis.
 */
