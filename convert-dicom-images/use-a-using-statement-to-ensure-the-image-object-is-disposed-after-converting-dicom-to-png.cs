using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output locations
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

            // Load the DICOM image and ensure it is disposed afterwards
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM‑specific members
                DicomImage dicomImage = image as DicomImage;
                if (dicomImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a DICOM image.");
                    return;
                }

                // Iterate through each page and save it as PNG
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
 * 1. Converting DICOM medical scans to PNG for integration into a web‑based patient portal.
 * 2. Extracting each frame of a multi‑page DICOM ultrasound study and saving them as separate PNG files for inclusion in a research paper.
 * 3. Automating the batch conversion of radiology images to PNG so they can be processed by a machine‑learning model that only accepts standard image formats.
 * 4. Preparing DICOM images for printing or archiving by converting them to lossless PNG while ensuring proper resource cleanup with a using statement.
 * 5. Validating that a received DICOM file is readable and then generating PNG thumbnails for quick preview in a hospital information system.
 */