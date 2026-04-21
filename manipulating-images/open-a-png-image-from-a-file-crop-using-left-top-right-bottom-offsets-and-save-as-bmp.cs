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
            // Hardcoded input and output file paths
            string inputPath = @"c:\temp\input.png";
            string outputPath = @"c:\temp\output.bmp";

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
                int leftOffset = 10;
                int rightOffset = 10;
                int topOffset = 20;
                int bottomOffset = 20;

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
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}