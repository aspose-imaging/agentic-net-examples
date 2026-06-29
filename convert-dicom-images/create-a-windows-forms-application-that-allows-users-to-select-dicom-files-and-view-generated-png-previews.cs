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
            // Hardcoded input DICOM file path
            string inputPath = "sample.dcm";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output directory for PNG previews
            string outputDirectory = "Previews";

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Open DICOM file as a stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Load DICOM image from stream
                using (DicomImage dicomImage = new DicomImage(stream))
                {
                    // Iterate through each page in the DICOM image
                    foreach (DicomPage page in dicomImage.DicomPages)
                    {
                        // Build PNG file path for the current page
                        string pngPath = Path.Combine(outputDirectory, $"page_{page.Index}.png");

                        // Ensure the directory for the PNG file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(pngPath));

                        // Save the page as a PNG image
                        page.Save(pngPath, new PngOptions());
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
 * 1. When a medical imaging application needs to generate quick PNG thumbnails of DICOM scans so radiologists can browse studies in a Windows Forms viewer.
 * 2. When a hospital IT system must automatically convert multi‑frame DICOM files into separate PNG images for integration with electronic health record portals.
 * 3. When a research lab wants to extract each slice of a 3D MRI DICOM series and save them as PNG files for analysis with standard image‑processing tools.
 * 4. When a developer builds a desktop program that lets users select a DICOM file and instantly preview its pages as PNGs without requiring external viewers.
 * 5. When a batch‑processing tool has to verify the existence of DICOM files, create an output folder, and export every DICOM page to PNG using Aspose.Imaging in C#.
 */