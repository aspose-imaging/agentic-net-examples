using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.bmp";

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

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Offsets for cropping: left, right, top, bottom
                int leftOffset = 10;   // pixels to remove from the left
                int rightOffset = 10;  // pixels to remove from the right
                int topOffset = 20;    // pixels to remove from the top
                int bottomOffset = 20; // pixels to remove from the bottom

                // Crop the image using the specified offsets
                image.Crop(leftOffset, rightOffset, topOffset, bottomOffset);

                // Prepare BMP save options (default options are sufficient here)
                BmpOptions bmpOptions = new BmpOptions();

                // Save the cropped image as BMP
                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}