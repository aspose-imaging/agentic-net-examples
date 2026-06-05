using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Ensure the output base directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all WMF files in the input directory
            string[] wmfFiles = Directory.GetFiles(inputDirectory, "*.wmf");

            foreach (string inputPath in wmfFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the WMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare output paths for each desired format
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);

                    // PNG
                    string pngPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");
                    Directory.CreateDirectory(Path.GetDirectoryName(pngPath));
                    image.Save(pngPath, new PngOptions());

                    // JPEG
                    string jpegPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");
                    Directory.CreateDirectory(Path.GetDirectoryName(jpegPath));
                    image.Save(jpegPath, new JpegOptions());

                    // BMP
                    string bmpPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));
                    image.Save(bmpPath, new BmpOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}