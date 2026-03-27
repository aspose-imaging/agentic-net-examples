using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.tif";
        string outputPath = @"C:\temp\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access rotation functionality
            TiffImage tiffImage = image as TiffImage;
            if (tiffImage == null)
            {
                Console.Error.WriteLine("Loaded image is not a TIFF.");
                return;
            }

            // Rotate 90 degrees clockwise, resize proportionally, black background
            tiffImage.Rotate(90f, true, Aspose.Imaging.Color.Black);

            // Save as BMP using default compression options
            tiffImage.Save(outputPath, new BmpOptions());
        }
    }
}