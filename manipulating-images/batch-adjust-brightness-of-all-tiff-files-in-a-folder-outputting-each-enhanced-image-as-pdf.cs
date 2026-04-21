using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Ensure the output base directory exists
            Directory.CreateDirectory(outputDir);

            // Collect all TIFF files (both .tif and .tiff extensions)
            List<string> allFiles = new List<string>();
            allFiles.AddRange(Directory.GetFiles(inputDir, "*.tif"));
            allFiles.AddRange(Directory.GetFiles(inputDir, "*.tiff"));

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

                    // Adjust brightness (example value: 50)
                    tiffImage.AdjustBrightness(50);

                    // Build the output PDF path
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".pdf");

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