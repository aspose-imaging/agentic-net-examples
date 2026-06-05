using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\InputCdr";
        string outputFolder = @"C:\OutputJpg";

        try
        {
            // Get all CDR files in the input folder
            string[] cdrFiles = Directory.GetFiles(inputFolder, "*.cdr");

            foreach (string inputPath in cdrFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    int pageIndex = 0;

                    // Iterate through each page of the CDR document
                    foreach (Image page in cdrImage.Pages)
                    {
                        // Build the output JPG file path
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_page{pageIndex}.jpg";
                        string outputPath = Path.Combine(outputFolder, outputFileName);

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as JPG with default options
                        JpegOptions jpegOptions = new JpegOptions();
                        page.Save(outputPath, jpegOptions);

                        pageIndex++;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}