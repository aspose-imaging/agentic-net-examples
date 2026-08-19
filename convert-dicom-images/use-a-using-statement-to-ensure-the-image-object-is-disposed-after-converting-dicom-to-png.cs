// HOW-TO: Convert Multi‑Page DICOM to PNG Files with Automatic Disposal in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputDirectory = "output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the DICOM image and ensure it is disposed after use
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM-specific members
                DicomImage dicomImage = image as DicomImage;
                if (dicomImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a DICOM image.");
                    return;
                }

                // Iterate through each DICOM page and save as PNG
                foreach (DicomPage dicomPage in dicomImage.DicomPages)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{dicomPage.Index}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG
                    dicomPage.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a hospital IT system needs to export each slice of a multi‑frame DICOM study as separate PNG images for integration with a web viewer.
 * 2. When a research project requires batch conversion of DICOM files to PNG while ensuring the Image objects are properly disposed to avoid memory leaks.
 * 3. When a radiology software developer wants to generate thumbnail PNGs from DICOM pages for quick preview in a patient portal.
 * 4. When a medical imaging workflow must save DICOM pages to a file system directory structure that may not exist beforehand.
 * 5. When a C# application needs to handle DICOM to PNG conversion using Aspose.Imaging with safe resource management via a using block.
 */
