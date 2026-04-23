using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "sample.dcm";
        string outputPath = "sample_flipped.png";

        try
        {
            // Verify that the input DICOM file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the DICOM image, flip it vertically, and save as PNG
            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                // Flip vertically (no rotation, only vertical flip)
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);

                // Save the transformed image as PNG
                image.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            // Output any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}