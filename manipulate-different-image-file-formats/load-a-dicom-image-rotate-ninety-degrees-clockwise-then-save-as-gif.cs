using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.dcm";
        string outputPath = "output.gif";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                // Rotate 90 degrees clockwise without flipping
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
 * 1. When a medical imaging application needs to display DICOM scans in a web browser that only supports GIF, a developer can load the DICOM, rotate it for correct orientation, and save it as a GIF file.
 * 2. When integrating radiology data into a patient portal, a developer may convert DICOM images to GIF after rotating them to match the viewer’s layout.
 * 3. When preparing DICOM screenshots for inclusion in a PowerPoint presentation, a developer can programmatically rotate the image and export it as a GIF.
 * 4. When building an automated pipeline that extracts DICOM frames, corrects orientation, and stores them as lightweight GIFs for archival or transmission, this code handles the transformation.
 * 5. When a hospital’s reporting tool must generate animated GIFs from a series of DICOM slices and ensure each slice is oriented correctly, a developer can use this code to rotate and save each slice.
 */