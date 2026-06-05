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
            string inputDir = "C:\\Temp\\TiffInput";
            string outputDir = "C:\\Temp\\PdfOutput";

            // Collect all .tif and .tiff files
            var tiffFiles = new List<string>();
            tiffFiles.AddRange(Directory.GetFiles(inputDir, "*.tif"));
            tiffFiles.AddRange(Directory.GetFiles(inputDir, "*.tiff"));

            foreach (var inputPath in tiffFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output PDF path
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load TIFF, apply gamma correction, and save as PDF
                using (Image image = Image.Load(inputPath))
                {
                    TiffImage tiffImage = (TiffImage)image;
                    tiffImage.AdjustGamma(1.3f);
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