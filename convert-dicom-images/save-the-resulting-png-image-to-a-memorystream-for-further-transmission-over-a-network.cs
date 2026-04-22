using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image from the input file
            using (Image image = Image.Load(inputPath))
            {
                // Create PNG save options (default settings)
                PngOptions pngOptions = new PngOptions();

                // Optional: save the PNG to a file path
                image.Save(outputPath, pngOptions);

                // Save the PNG image to a MemoryStream for network transmission
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, pngOptions);
                    // Reset stream position if it will be read later
                    memoryStream.Position = 0;

                    // Example output: report the size of the PNG data
                    Console.WriteLine($"PNG image saved to memory stream, size: {memoryStream.Length} bytes");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}