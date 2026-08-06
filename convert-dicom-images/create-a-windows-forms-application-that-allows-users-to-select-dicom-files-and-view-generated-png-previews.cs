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
        try
        {
            // Hardcoded input DICOM file and output directory
            string inputPath = "Input/sample.dcm";
            string outputDirectory = "Output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load DICOM image and generate PNG previews for each page
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                int pageIndex = 0;
                foreach (var dicomPage in dicomImage.DicomPages)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.png");
                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG
                    dicomPage.Save(outputPath, new PngOptions());

                    pageIndex++;
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
 * 1. When a radiology application needs to let clinicians quickly preview multi‑frame DICOM studies as PNG thumbnails in a Windows Forms viewer.
 * 2. When a health‑tech startup wants to generate web‑ready PNG snapshots from DICOM files for integration into electronic health record portals.
 * 3. When a research lab must batch‑convert DICOM series into PNG images for machine‑learning preprocessing using C# and Aspose.Imaging.
 * 4. When a hospital IT team needs a simple Windows desktop tool that lets users select a DICOM file and instantly view each slice as a PNG without installing a full PACS viewer.
 * 5. When a medical device manufacturer requires an automated C# utility to extract every page of a multi‑page DICOM file and save them as PNG files for quality‑control documentation.
 */