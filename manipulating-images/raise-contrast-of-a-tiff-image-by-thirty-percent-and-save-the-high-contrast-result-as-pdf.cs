using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.tif";
        string outputPath = @"C:\temp\sample_contrast.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image, adjust contrast, and save as PDF
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access AdjustContrast
            TiffImage tiffImage = (TiffImage)image;

            // Increase contrast by 30%
            tiffImage.AdjustContrast(30f);

            // Save the result as PDF
            tiffImage.Save(outputPath, new PdfOptions());
        }
    }
}