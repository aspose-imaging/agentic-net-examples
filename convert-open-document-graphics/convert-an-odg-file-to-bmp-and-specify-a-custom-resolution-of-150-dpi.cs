using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.odg";
        string outputPath = @"C:\temp\sample_150dpi.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image odgImage = Image.Load(inputPath))
        {
            // Save it as BMP (default resolution)
            odgImage.Save(outputPath, new BmpOptions());
        }

        // Reload the BMP to adjust its resolution
        using (BmpImage bmpImage = (BmpImage)Image.Load(outputPath))
        {
            // Set custom resolution to 150 DPI
            bmpImage.SetResolution(150.0, 150.0);

            // Save the BMP with the new resolution (overwrite)
            bmpImage.Save(outputPath);
        }
    }
}