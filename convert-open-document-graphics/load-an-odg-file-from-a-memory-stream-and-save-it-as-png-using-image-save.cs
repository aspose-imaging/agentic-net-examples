using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.odg";
        string outputPath = "output\\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG file into a memory stream
        using (FileStream fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                fileStream.CopyTo(memoryStream);
                memoryStream.Position = 0;

                // Load the image from the memory stream
                using (Image image = Image.Load(memoryStream))
                {
                    // Save the image as PNG
                    PngOptions pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
                }
            }
        }
    }
}