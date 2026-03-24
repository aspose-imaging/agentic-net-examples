using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Define the cropping rectangle (example: central region)
            int left = image.Width / 4;
            int top = image.Height / 4;
            int width = image.Width / 2;
            int height = image.Height / 2;
            var cropArea = new Aspose.Imaging.Rectangle(left, top, width, height);

            // Crop the image
            image.Crop(cropArea);

            // Save the cropped image as APNG
            var apngOptions = new ApngOptions();
            image.Save(outputPath, apngOptions);
        }
    }
}