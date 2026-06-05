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
            string inputDirectory = @"C:\InputImages";
            string outputDirectory = @"C:\OutputPdfs";

            // Ensure the output directory exists (will also handle subfolders)
            Directory.CreateDirectory(outputDirectory);

            // Get all TIFF files in the input directory (both .tif and .tiff)
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");
            string[] tiffFilesAlt = Directory.GetFiles(inputDirectory, "*.tiff");
            string[] allTiffFiles = new string[tiffFiles.Length + tiffFilesAlt.Length];
            tiffFiles.CopyTo(allTiffFiles, 0);
            tiffFilesAlt.CopyTo(allTiffFiles, tiffFiles.Length);

            foreach (string inputPath in allTiffFiles)
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
                    // Cast to TiffImage to access AdjustContrast
                    TiffImage tiffImage = (TiffImage)image;

                    // Increase contrast by 50 (range -100 to 100)
                    tiffImage.AdjustContrast(50f);

                    // Prepare output PDF path (same file name, .pdf extension)
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure the output directory exists (covers cases where outputPath may include subfolders)
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