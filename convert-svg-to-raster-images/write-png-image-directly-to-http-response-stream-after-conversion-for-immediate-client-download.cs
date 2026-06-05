using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input image path
            string inputPath = "Input/sample.bmp";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output path (simulating HTTP response stream)
            string outputPath = "Output/converted.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options
                PngOptions pngOptions = new PngOptions
                {
                    CompressionLevel = 9 // maximum compression
                };

                // Write the PNG directly to the response stream (here a FileStream simulates the HTTP response)
                using (FileStream responseStream = new FileStream(outputPath, FileMode.Create))
                {
                    image.Save(responseStream, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}