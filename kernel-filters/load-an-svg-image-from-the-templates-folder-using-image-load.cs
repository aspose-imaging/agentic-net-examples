using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path to the SVG file in the templates folder
            string inputPath = "templates/sample.svg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the SVG image using Aspose.Imaging.Image.Load
            using (Image image = Image.Load(inputPath))
            {
                // Example usage: output basic information about the loaded image
                Console.WriteLine($"Successfully loaded SVG image: {inputPath}");
                Console.WriteLine($"Dimensions: {image.Width}x{image.Height}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}