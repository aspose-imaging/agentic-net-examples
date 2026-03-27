using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\sample.odg";
        string outputPath = @"C:\Temp\Result\sample.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image, rotate it, and save as JPEG
        using (Image image = Image.Load(inputPath))
        {
            // Cast to OdgImage to access RotateFlip
            OdgImage odgImage = (OdgImage)image;
            odgImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Save as JPEG using default JPEG options
            JpegOptions jpegOptions = new JpegOptions();
            odgImage.Save(outputPath, jpegOptions);
        }
    }
}