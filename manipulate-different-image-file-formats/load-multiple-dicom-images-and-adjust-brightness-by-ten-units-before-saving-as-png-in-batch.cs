using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = @"C:\InputDICOM\";
        string outputDir = @"C:\OutputPNG\";

        // List of DICOM files to process (hardcoded)
        string[] files = new string[]
        {
            "image1.dcm",
            "image2.dcm",
            "image3.dcm"
        };

        foreach (var fileName in files)
        {
            // Build full input path
            string inputPath = Path.Combine(inputDir, fileName);

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM-specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Adjust brightness by 10 units
                dicomImage.AdjustBrightness(10);

                // Prepare output path (same name with .png extension)
                string outputFileName = Path.ChangeExtension(fileName, ".png");
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save as PNG
                dicomImage.Save(outputPath, new PngOptions());
            }
        }
    }
}