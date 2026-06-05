using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Wrap the entire processing in a try-catch to handle unexpected errors gracefully.
        try
        {
            // Hardcoded input and output directories.
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Get all BMP files in the input folder.
            string[] bmpFiles = Directory.GetFiles(inputFolder, "*.bmp");

            foreach (string inputPath in bmpFiles)
            {
                // Verify that the input file exists.
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the BMP image.
                using (Image image = Image.Load(inputPath))
                {
                    // Ensure the image is large enough for a 10-pixel border crop.
                    if (image.Width <= 20 || image.Height <= 20)
                    {
                        Console.Error.WriteLine($"Image too small to crop: {inputPath}");
                        continue;
                    }

                    // Crop a 10-pixel border from each side.
                    int cropX = 10;
                    int cropY = 10;
                    int cropWidth = image.Width - 20;
                    int cropHeight = image.Height - 20;
                    image.Crop(new Aspose.Imaging.Rectangle(cropX, cropY, cropWidth, cropHeight));

                    // Prepare the output file path with a .png extension.
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                    // Ensure the output directory exists.
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the cropped image as PNG.
                    image.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            // Output any unexpected errors.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}