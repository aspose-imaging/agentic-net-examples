using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Get all PNG files in the input folder
            string[] pngFiles = Directory.GetFiles(inputFolder, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the PNG image
                using (PngImage pngImage = new PngImage(inputPath))
                {
                    // Resize to 640x480
                    pngImage.Resize(640, 480);

                    // Prepare output BMP path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".bmp";
                    string outputPath = Path.Combine(outputFolder, outputFileName);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as BMP
                    pngImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}