using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output_cropped.bmp";

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

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Define the rectangle to crop (left, top, width, height)
                // Example: crop a 200x150 region starting at (50, 30)
                int left = 50;
                int top = 30;
                int width = 200;
                int height = 150;
                var cropArea = new Rectangle(left, top, width, height);

                // Perform the crop operation
                image.Crop(cropArea);

                // Save the cropped image (same format as input by default)
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}