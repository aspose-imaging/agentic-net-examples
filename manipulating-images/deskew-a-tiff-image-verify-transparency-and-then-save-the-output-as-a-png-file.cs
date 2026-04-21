using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.tif";
        string outputPath = "Output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                // Deskew the image
                tiff.NormalizeAngle();

                // Verify transparency
                bool hasAlpha = tiff.HasAlpha;
                Console.WriteLine($"Image has alpha channel: {hasAlpha}");

                // Save as PNG
                PngOptions pngOptions = new PngOptions();
                tiff.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}