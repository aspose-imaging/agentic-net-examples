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
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Ensure the output directory exists (creates parent if needed)
            Directory.CreateDirectory(outputDirectory);

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");
            string[] tiffFilesUpper = Directory.GetFiles(inputDirectory, "*.tiff");
            string[] allFiles = new string[tiffFiles.Length + tiffFilesUpper.Length];
            tiffFiles.CopyTo(allFiles, 0);
            tiffFilesUpper.CopyTo(allFiles, tiffFiles.Length);

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
                    // Cast to TiffImage to access AdjustContrast
                    TiffImage tiffImage = (TiffImage)image;

                    // Increase contrast (value in range [-100, 100])
                    tiffImage.AdjustContrast(50f);

                    // Prepare output PDF path (same file name, .pdf extension)
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure the output directory exists (unconditional as per rules)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as PDF
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