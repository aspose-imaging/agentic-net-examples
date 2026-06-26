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
            // Hardcoded input and output paths
            string inputPath = "input.dcm";
            string outputDirectory = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the DICOM image and ensure it is disposed after use
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DicomPages
                DicomImage dicomImage = image as DicomImage;
                if (dicomImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a valid DICOM image.");
                    return;
                }

                // Iterate through each page and save as PNG
                foreach (DicomPage page in dicomImage.DicomPages)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{page.Index}.png");

                    // Ensure the directory for this file exists (covers cases where outputPath may contain subfolders)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG
                    page.Save(outputPath, new PngOptions());
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
 * 1. When a hospital's PACS system needs to generate thumbnail PNG previews of each DICOM slice for quick web viewing.
 * 2. When a medical research application must batch‑convert DICOM scans into PNG files to embed them in a PDF report.
 * 3. When a telemedicine platform wants to stream individual DICOM pages as PNG images to a browser without keeping the original file open.
 * 4. When a radiology AI pipeline extracts PNG frames from multi‑frame DICOM studies for preprocessing with standard image libraries.
 * 5. When a healthcare IT team automates the archival of DICOM images by saving each page as a PNG in a structured output folder while ensuring resources are released.
 */