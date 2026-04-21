using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input DICOM file paths
        string[] inputPaths = new string[]
        {
            "input1.dcm",
            "input2.dcm",
            "input3.dcm"
        };

        // Hardcoded output directory
        string outputDir = "output";

        foreach (var inputPath in inputPaths)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;

                // Adjust contrast; factor 1.3 approximated as a +30 value
                dicomImage.AdjustContrast(30f);

                // Build output file path (GIF format)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".gif";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the adjusted image as GIF
                dicomImage.Save(outputPath, new GifOptions());
            }
        }
    }
}