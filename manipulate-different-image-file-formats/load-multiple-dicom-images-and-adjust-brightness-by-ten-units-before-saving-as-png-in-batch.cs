using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input folder and output folder
            string inputFolder = @"C:\Images\Dicom\Input";
            string outputFolder = @"C:\Images\Dicom\Output";

            // List of DICOM files to process
            string[] inputFiles = new string[]
            {
                Path.Combine(inputFolder, "image1.dcm"),
                Path.Combine(inputFolder, "image2.dcm"),
                Path.Combine(inputFolder, "image3.dcm")
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path (same name with .png extension)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DICOM image, adjust brightness, and save as PNG
                using (Image image = Image.Load(inputPath))
                {
                    DicomImage dicomImage = (DicomImage)image;
                    dicomImage.AdjustBrightness(10);
                    dicomImage.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}