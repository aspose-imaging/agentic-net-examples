using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\Images\Input";
        string outputDirectory = @"C:\Images\Output";

        try
        {
            // Get all files in the input directory (you can adjust the search pattern as needed)
            string[] inputFiles = Directory.GetFiles(inputDirectory);

            foreach (string inputPath in inputFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // ----- Cropping -----
                    // Crop to the central rectangle (half width and half height)
                    var cropRect = new Rectangle(
                        image.Width / 4,
                        image.Height / 4,
                        image.Width / 2,
                        image.Height / 2);
                    image.Crop(cropRect);

                    // ----- Rotation -----
                    // Rotate 90 degrees clockwise without flipping
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                    // ----- Resizing -----
                    // Resize to 50% of the current dimensions
                    int newWidth = image.Width / 2;
                    int newHeight = image.Height / 2;
                    image.Resize(newWidth, newHeight);

                    // Prepare output path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_processed" + Path.GetExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the processed image
                    image.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}