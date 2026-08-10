// HOW-TO: Rotate DICOM Image 90 Degrees Clockwise and Save as GIF in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output file paths
            string inputPath = "input.dcm";
            string outputPath = "output.gif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the DICOM image
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                // Rotate 90 degrees clockwise
                dicomImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save the rotated image as GIF
                dicomImage.Save(outputPath, new GifOptions());
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
 * 1. When a medical imaging application needs to display DICOM scans as GIF thumbnails after rotating them for correct orientation.
 * 2. When a radiology web portal must convert uploaded DICOM files to GIF format for quick preview in browsers that do not support DICOM.
 * 3. When a healthcare data pipeline requires reorienting DICOM images before archiving them as lightweight GIFs for reporting.
 * 4. When a diagnostic tool needs to rotate patient scans by 90 degrees to match the viewer’s layout and then save them as GIFs for inclusion in documentation.
 * 5. When a mobile health app must transform DICOM images into GIFs with proper orientation to reduce file size and improve loading speed.
 */
