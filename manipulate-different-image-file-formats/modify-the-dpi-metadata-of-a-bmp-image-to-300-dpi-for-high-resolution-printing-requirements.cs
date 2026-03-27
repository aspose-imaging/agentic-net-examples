using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output_300dpi.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image, set its resolution to 300 DPI, and save
        using (Image image = Image.Load(inputPath))
        {
            BmpImage bmpImage = (BmpImage)image;
            bmpImage.SetResolution(300.0, 300.0);
            bmpImage.Save(outputPath);
        }
    }
}