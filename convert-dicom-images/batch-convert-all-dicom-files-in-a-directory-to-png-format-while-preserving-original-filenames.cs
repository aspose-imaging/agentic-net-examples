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
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputDicom";
            string outputDirectory = @"C:\OutputPng";

            // Get all DICOM files in the input directory
            string[] dicomFiles = Directory.GetFiles(inputDirectory, "*.dcm");

            foreach (string inputPath in dicomFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output PNG path preserving the original file name
                string outputPath = Path.Combine(
                    outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the DICOM image from a file stream
                using (Stream stream = File.OpenRead(inputPath))
                using (DicomImage dicomImage = new DicomImage(stream))
                {
                    // If the DICOM image has multiple pages, convert the first page.
                    // Adjust as needed for multi‑page handling.
                    var firstPage = dicomImage.DicomPages[0];
                    firstPage.Save(outputPath, new PngOptions());
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
 * 1. When a radiology department needs to export a whole folder of DICOM scans to PNG files for inclusion in patient reports or web portals.
 * 2. When a medical imaging researcher wants to preprocess a dataset by converting all DICOM images in a directory to PNG format for use with machine‑learning libraries that accept only common raster formats.
 * 3. When a hospital IT team automates the migration of legacy DICOM archives to a cloud storage solution that only supports PNG thumbnails for quick preview.
 * 4. When a developer builds a C# desktop utility that batch converts DICOM files to PNG while preserving original filenames to maintain traceability between source scans and generated images.
 * 5. When a quality‑control engineer needs to generate visual PNG copies of DICOM images from a scanner output folder to verify image integrity without opening specialized DICOM viewers.
 */