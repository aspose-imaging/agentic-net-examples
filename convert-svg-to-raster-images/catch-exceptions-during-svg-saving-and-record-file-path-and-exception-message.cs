using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Wrap the entire logic in a try-catch to handle unexpected errors.
        try
        {
            // Hardcoded input and output file paths.
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.svg";

            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists.
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image.
            using (Image image = Image.Load(inputPath))
            {
                // Attempt to save the image as SVG and capture any save-specific exceptions.
                try
                {
                    image.Save(outputPath, new SvgOptions());
                }
                catch (Exception ex)
                {
                    // Record the file path and exception message for save failures.
                    Console.Error.WriteLine($"Error saving {outputPath}: {ex.Message}");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            // Log any other unexpected errors.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}