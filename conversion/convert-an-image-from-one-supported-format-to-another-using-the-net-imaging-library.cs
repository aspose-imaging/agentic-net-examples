using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.png";

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
            // Prepare PNG save options (default settings)
            PngOptions saveOptions = new PngOptions();

            // Optional: verify that the image can be saved with these options
            if (!image.CanSave(saveOptions))
            {
                Console.Error.WriteLine("The image cannot be saved in the requested format.");
                return;
            }

            // Save the image to the output path
            image.Save(outputPath, saveOptions);
        }

        Console.WriteLine("Image conversion completed successfully.");
    }
}