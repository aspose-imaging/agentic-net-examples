using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.dcm";
        string outputPath = "Output/rotated.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DICOM image, rotate, and save as PNG
        using (Aspose.Imaging.FileFormats.Dicom.DicomImage dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Rotate 90 degrees clockwise, resize proportionally, black background
            dicomImage.Rotate(90f, true, Aspose.Imaging.Color.Black);

            // Save rotated image as PNG
            using (PngOptions pngOptions = new PngOptions())
            {
                dicomImage.Save(outputPath, pngOptions);
            }
        }
    }
}