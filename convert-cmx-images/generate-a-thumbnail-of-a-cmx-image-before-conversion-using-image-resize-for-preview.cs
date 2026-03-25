using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cmx";
        string outputPath = @"C:\Images\thumbnail.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image
        using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
        {
            // Define thumbnail dimensions (width fixed, height proportional)
            int thumbWidth = 200;
            int thumbHeight = (int)(cmxImage.Height * thumbWidth / (double)cmxImage.Width);

            // Resize the image to create a thumbnail
            cmxImage.Resize(thumbWidth, thumbHeight);

            // Save the thumbnail as PNG
            var pngOptions = new PngOptions();
            cmxImage.Save(outputPath, pngOptions);
        }
    }
}