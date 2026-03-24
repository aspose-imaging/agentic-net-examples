using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (Image tiffImage = Image.Load(inputPath))
        {
            // Metadata is retained within the Image instance.
            // Create JPEG options (default quality, can be adjusted if needed)
            JpegOptions jpegOptions = new JpegOptions();

            // Save the image as JPEG, preserving metadata automatically
            tiffImage.Save(outputPath, jpegOptions);
        }
    }
}