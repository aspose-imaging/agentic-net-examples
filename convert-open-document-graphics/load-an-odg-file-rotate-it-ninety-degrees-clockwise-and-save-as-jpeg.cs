using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.odg";
            string outputPath = "output\\rotated.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to OdgImage to access specific methods
                OdgImage odgImage = (OdgImage)image;

                // Rotate 90 degrees clockwise
                odgImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save as JPEG
                JpegOptions jpegOptions = new JpegOptions();
                odgImage.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}