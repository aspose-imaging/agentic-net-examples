using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "c:\\temp\\source.bmp";
        string outputPath = "c:\\temp\\output.jp2";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the bitmap source image
            using (Image bitmap = Image.Load(inputPath))
            {
                // Set up JPEG2000 options for lossless compression
                Jpeg2000Options options = new Jpeg2000Options
                {
                    Irreversible = false // Use lossless DWT 5-3 compression
                };

                // Save the image as JPEG2000
                bitmap.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}