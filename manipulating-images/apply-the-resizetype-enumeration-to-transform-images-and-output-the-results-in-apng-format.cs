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
        string inputPath = "input.png";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Determine new dimensions (e.g., reduce size by 50%)
            int newWidth = image.Width / 2;
            int newHeight = image.Height / 2;

            // Resize using a specific ResizeType (e.g., CatmullRom)
            image.Resize(newWidth, newHeight, ResizeType.CatmullRom);

            // Save the resized image as an APNG file
            var apngOptions = new ApngOptions();
            image.Save(outputPath, apngOptions);
        }
    }
}