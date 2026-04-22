using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\InputDicom";
            string outputDir = @"C:\OutputPng";

            // Get all DICOM files in the input directory
            string[] dicomFiles = Directory.GetFiles(inputDir, "*.dcm");

            foreach (string dicomPath in dicomFiles)
            {
                // Verify the input file exists
                if (!File.Exists(dicomPath))
                {
                    Console.Error.WriteLine($"File not found: {dicomPath}");
                    return;
                }

                // Load the DICOM image
                using (Image dicomImage = Image.Load(dicomPath))
                {
                    // Build the output PNG file path (preserve original filename)
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(dicomPath);
                    string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".png");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the image as PNG
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