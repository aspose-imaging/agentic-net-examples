using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

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

            // Load the JPEG image
            using (JpegImage image = new JpegImage(inputPath))
            {
                // Resize to 800x600
                image.Resize(800, 600);

                // Choose a reference point for the magic wand (center of the image)
                int refX = image.Width / 2;
                int refY = image.Height / 2;

                // Apply Magic Wand selection with threshold 40 and apply the mask
                MagicWandTool
                    .Select(image, new MagicWandSettings(refX, refY) { Threshold = 40 })
                    .Apply();

                // Save the processed image
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Output any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}