using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Core;
using Aspose.Imaging.FileFormats.Core.Photo.Hdr;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output directories
        string inputDirectory = @"C:\Images\Input";
        string outputDirectory = @"C:\Images\Output";

        try
        {
            // Enumerate all files in the input directory
            foreach (string filePath in Directory.GetFiles(inputDirectory))
            {
                // Verify the input file exists
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                // Load the image
                using (Image image = Image.Load(filePath))
                {
                    // ----- Cropping -----
                    // Example: crop 10% from each side
                    int cropLeft = image.Width / 10;
                    int cropTop = image.Height / 10;
                    int cropWidth = image.Width - 2 * cropLeft;
                    int cropHeight = image.Height - 2 * cropTop;
                    var cropRect = new Rectangle(cropLeft, cropTop, cropWidth, cropHeight);
                    image.Crop(cropRect);

                    // ----- Rotation -----
                    // Rotate 90 degrees clockwise without flipping
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                    // ----- Resizing -----
                    // Example: resize to 50% of the current dimensions
                    int newWidth = image.Width / 2;
                    int newHeight = image.Height / 2;
                    // The Resize method is part of Aspose.Imaging's image operations
                    image.Resize(newWidth, newHeight);

                    // Prepare output path
                    string outputFileName = Path.GetFileNameWithoutExtension(filePath) + "_processed" + Path.GetExtension(filePath);
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