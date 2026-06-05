using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\output\processed.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare BMP save options (default settings)
                BmpOptions bmpOptions = new BmpOptions();

                // Save the image to a MemoryStream for in‑memory processing
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, bmpOptions);
                    Console.WriteLine($"Image saved to memory stream. Length = {memoryStream.Length} bytes.");
                    // Further in‑memory processing can be performed here
                }

                // Optionally, also save the image to a file using the same options
                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}