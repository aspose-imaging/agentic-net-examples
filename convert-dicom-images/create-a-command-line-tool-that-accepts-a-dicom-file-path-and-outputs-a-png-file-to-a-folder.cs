using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\input\sample.dcm";
        string outputPath = @"C:\output\sample.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DICOM image from file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DicomImage dicomImage = new DicomImage(stream))
            {
                // If the DICOM file has multiple pages, save the first one.
                // Otherwise, save the single page.
                var dicomPage = dicomImage.DicomPages[0];
                dicomPage.Save(outputPath, new PngOptions());
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
 * 1. When a medical imaging application must convert DICOM scans to PNG thumbnails for web preview, a developer can use this command‑line tool to read the .dcm file and output a .png image.
 * 2. When integrating radiology workflow automation, a developer needs to extract the first frame of a multi‑page DICOM series and save it as a PNG for inclusion in patient reports.
 * 3. When building a batch processing script that archives diagnostic images in a universal format, a developer can invoke this utility to transform each DICOM file into a PNG file stored in a designated folder.
 * 4. When a hospital’s PACS system requires a lightweight image for mobile devices, a developer can employ this code to convert the DICOM file to a PNG that can be displayed on smartphones.
 * 5. When performing image analysis with third‑party libraries that only support PNG, a developer can use this tool to convert incoming DICOM files to PNG before feeding them into the analysis pipeline.
 */