using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load BMP image, set DPI to 300, and save
        using (Image image = Image.Load(inputPath))
        {
            BmpImage bmpImage = (BmpImage)image;
            bmpImage.SetResolution(300.0, 300.0);
            bmpImage.Save(outputPath);
        }
    }
}