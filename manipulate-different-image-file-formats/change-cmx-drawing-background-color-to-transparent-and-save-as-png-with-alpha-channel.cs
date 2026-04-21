using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.cmx";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image
        using (Image image = Image.Load(inputPath))
        {
            var cmxImage = image as CmxImage;
            if (cmxImage == null)
            {
                Console.Error.WriteLine("Failed to load CMX image.");
                return;
            }

            // Set background color to fully transparent
            cmxImage.BackgroundColor = Aspose.Imaging.Color.Transparent;
            cmxImage.HasBackgroundColor = true;

            // Save the image as PNG with alpha channel
            var pngOptions = new PngOptions();
            cmxImage.Save(outputPath, pngOptions);
        }
    }
}