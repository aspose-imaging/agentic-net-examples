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
        string inputPath = "input.dcm";
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the DICOM image, crop, and save as GIF
        using (Image image = Image.Load(inputPath))
        {
            DicomImage dicomImage = (DicomImage)image;

            // Crop to rectangle (0,0,200,200)
            dicomImage.Crop(new Rectangle(0, 0, 200, 200));

            // Save the cropped image as GIF
            dicomImage.Save(outputPath, new GifOptions());
        }
    }
}