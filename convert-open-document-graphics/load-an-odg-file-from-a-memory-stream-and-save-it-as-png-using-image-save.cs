using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.odg";
        string outputPath = "output\\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG file into a memory stream
        byte[] fileBytes = File.ReadAllBytes(inputPath);
        using (MemoryStream memoryStream = new MemoryStream(fileBytes))
        {
            // Load image from the memory stream
            using (Image image = Image.Load(memoryStream))
            {
                // Save the image as PNG
                PngOptions pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
        }
    }
}