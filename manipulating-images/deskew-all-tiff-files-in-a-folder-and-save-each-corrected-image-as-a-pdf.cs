using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output folders
            string inputFolder = @"C:\InputTiffs\";
            string outputFolder = @"C:\OutputPdfs\";

            // Get all TIFF files in the input folder
            string[] tiffFiles = Directory.GetFiles(inputFolder, "*.tif");
            string[] tiffFilesAlt = Directory.GetFiles(inputFolder, "*.tiff");
            string[] allFiles = new string[tiffFiles.Length + tiffFilesAlt.Length];
            tiffFiles.CopyTo(allFiles, 0);
            tiffFilesAlt.CopyTo(allFiles, tiffFiles.Length);

            foreach (string inputPath in allFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output PDF path
                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
                {
                    // Deskew the image (do not resize, use LightGray background)
                    tiffImage.NormalizeAngle(false, Color.LightGray);

                    // Save as PDF
                    var pdfOptions = new PdfOptions();
                    tiffImage.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}