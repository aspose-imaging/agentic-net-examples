using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = @"C:\Input\";
        string outputDir = @"C:\Output\";

        // List of DICOM files to process
        string[] dicomFiles = new[]
        {
            "image1.dcm",
            "image2.dcm",
            "image3.dcm"
        };

        foreach (string fileName in dicomFiles)
        {
            // Build full input and output paths
            string inputPath = Path.Combine(inputDir, fileName);
            string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(fileName) + ".png");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image, adjust brightness, and save as PNG
            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;
                dicomImage.AdjustBrightness(10); // Increase brightness by 10 units
                dicomImage.Save(outputPath, new PngOptions());
            }
        }
    }
}