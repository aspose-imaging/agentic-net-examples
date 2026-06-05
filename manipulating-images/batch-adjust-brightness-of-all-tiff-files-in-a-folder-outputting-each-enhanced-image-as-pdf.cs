using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputTiff";
            string outputFolder = @"C:\OutputPdf";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all TIFF files in the input folder (both .tif and .tiff)
            string[] tiffFiles = Directory.GetFiles(inputFolder, "*.tif");
            string[] tiffFilesAlt = Directory.GetFiles(inputFolder, "*.tiff");
            string[] allFiles = new string[tiffFiles.Length + tiffFilesAlt.Length];
            tiffFiles.CopyTo(allFiles, 0);
            tiffFilesAlt.CopyTo(allFiles, tiffFiles.Length);

            foreach (string inputPath in allFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to TiffImage to access AdjustBrightness
                    TiffImage tiffImage = (TiffImage)image;

                    // Adjust brightness (value in range [-255, 255])
                    tiffImage.AdjustBrightness(50);

                    // Prepare output PDF path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                    string outputPath = Path.Combine(outputFolder, outputFileName);

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the adjusted image as PDF
                    tiffImage.Save(outputPath, new PdfOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}