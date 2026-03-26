using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (unconditionally)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Set up PNG save options
            PngOptions pngOptions = new PngOptions();

            // Save the image to a memory stream for network transmission
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, pngOptions);
                // Reset stream position if further reading is needed
                memoryStream.Position = 0;

                // Example: display the size of the generated PNG data
                Console.WriteLine($"PNG image size in bytes: {memoryStream.Length}");
                // The memoryStream now contains the PNG image data ready for transmission
            }
        }
    }
}