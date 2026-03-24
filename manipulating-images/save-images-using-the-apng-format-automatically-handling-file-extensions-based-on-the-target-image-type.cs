using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.webp";
        string outputPath = "output.webp.png";

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
            // Prepare APNG save options (default settings)
            ApngOptions apngOptions = new ApngOptions();

            // Optional: verify that the image can be saved with these options
            if (!image.CanSave(apngOptions))
            {
                Console.Error.WriteLine("The loaded image cannot be saved as APNG with the provided options.");
                return;
            }

            // Save the image as APNG
            image.Save(outputPath, apngOptions);
        }
    }
}