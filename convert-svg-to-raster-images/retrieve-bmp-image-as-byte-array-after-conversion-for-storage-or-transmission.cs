using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.bmp";
        string outputPath = @"c:\temp\output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Define PNG save options (conversion)
                PngOptions pngOptions = new PngOptions();

                // Save the converted image to a memory stream
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, pngOptions);
                    byte[] imageBytes = ms.ToArray();

                    // Optionally, write the byte array to a file for verification
                    File.WriteAllBytes(outputPath, imageBytes);

                    Console.WriteLine($"Converted image size in bytes: {imageBytes.Length}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}