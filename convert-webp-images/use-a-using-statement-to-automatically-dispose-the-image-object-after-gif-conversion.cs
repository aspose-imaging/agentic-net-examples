using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace GifConversionExample
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\input.gif";
            string outputPath = @"C:\temp\output.gif";

            // Wrap the whole process in a try-catch to handle unexpected errors gracefully
            try
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists (creates it if necessary)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the GIF image and automatically dispose it after use
                using (Image image = Image.Load(inputPath))
                {
                    // Save the image to the output path (same format, can be changed with options if needed)
                    image.Save(outputPath);
                }
            }
            catch (Exception ex)
            {
                // Output any error message without crashing the application
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}