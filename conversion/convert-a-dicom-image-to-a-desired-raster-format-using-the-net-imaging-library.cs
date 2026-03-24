using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.dcm";
        string outputPath = "output.png";

        // Verify that the input DICOM file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image using Aspose.Imaging
        using (Image dicomImage = Image.Load(inputPath))
        {
            // Convert and save the image to PNG format
            dicomImage.Save(outputPath, new PngOptions());
        }
    }
}