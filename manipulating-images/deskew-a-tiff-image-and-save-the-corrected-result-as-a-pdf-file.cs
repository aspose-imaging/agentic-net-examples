using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.tif";
        string outputPath = @"C:\temp\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access NormalizeAngle
            if (image is TiffImage tiffImage)
            {
                // Deskew the image (resize proportionally, white background)
                tiffImage.NormalizeAngle(resizeProportionally: true, backgroundColor: Color.White);
            }

            // Save the corrected image as PDF
            image.Save(outputPath, new PdfOptions());
        }
    }
}