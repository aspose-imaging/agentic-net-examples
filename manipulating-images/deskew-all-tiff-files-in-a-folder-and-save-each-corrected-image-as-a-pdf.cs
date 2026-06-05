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
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Gather all TIFF files in the input folder
            var tiffFiles = new List<string>();
            tiffFiles.AddRange(Directory.GetFiles(inputFolder, "*.tif"));
            tiffFiles.AddRange(Directory.GetFiles(inputFolder, "*.tiff"));

            foreach (string inputPath in tiffFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output PDF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image, deskew, and save as PDF
                using (TiffImage image = (TiffImage)Image.Load(inputPath))
                {
                    // Deskew the image (do not resize, use LightGray background)
                    image.NormalizeAngle(false, Aspose.Imaging.Color.LightGray);

                    // Save the corrected image as PDF
                    var pdfOptions = new PdfOptions();
                    image.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}