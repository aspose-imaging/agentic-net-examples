using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputCdr";
            string outputFolder = @"C:\OutputJpg";

            // Get all CDR files in the input folder
            string[] cdrFiles = Directory.GetFiles(inputFolder, "*.cdr");

            foreach (string cdrFilePath in cdrFiles)
            {
                // Verify input file exists
                if (!File.Exists(cdrFilePath))
                {
                    Console.Error.WriteLine($"File not found: {cdrFilePath}");
                    return;
                }

                // Determine output JPG path
                string outputFileName = Path.GetFileNameWithoutExtension(cdrFilePath) + ".jpg";
                string outputFilePath = Path.Combine(outputFolder, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(cdrFilePath))
                {
                    // Save as JPG with default options
                    JpegOptions jpegOptions = new JpegOptions();
                    cdrImage.Save(outputFilePath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}