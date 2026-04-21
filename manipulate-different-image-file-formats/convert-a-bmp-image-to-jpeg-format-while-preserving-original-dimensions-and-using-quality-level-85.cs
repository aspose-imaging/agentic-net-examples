using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully.
        try
        {
            // Hardcoded input and output file paths.
            string inputPath = @"C:\temp\input.bmp";
            string outputPath = @"C:\temp\output.jpg";

            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary).
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image.
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options with the required quality.
                JpegOptions saveOptions = new JpegOptions
                {
                    Quality = 85
                };

                // Save the image as JPEG, preserving original dimensions.
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            // Output any runtime errors without crashing the program.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}