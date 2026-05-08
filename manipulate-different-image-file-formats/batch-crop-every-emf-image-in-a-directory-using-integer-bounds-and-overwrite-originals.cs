using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing EMF files.
            string inputDirectory = "Input";

            // Ensure the input directory exists.
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add EMF files and rerun.");
                return;
            }

            // Get all EMF files in the directory.
            string[] emfFiles = Directory.GetFiles(inputDirectory, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Verify the file exists.
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Load the EMF image.
                using (Image image = Image.Load(inputPath))
                {
                    EmfImage emfImage = (EmfImage)image;

                    // Define crop rectangle (example: inset by 10 pixels on each side).
                    int inset = 10;
                    int cropX = inset;
                    int cropY = inset;
                    int cropWidth = Math.Max(0, emfImage.Width - 2 * inset);
                    int cropHeight = Math.Max(0, emfImage.Height - 2 * inset);
                    Rectangle cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);

                    // Perform cropping.
                    emfImage.Crop(cropRect);

                    // Ensure the output directory exists (same as input directory here).
                    Directory.CreateDirectory(Path.GetDirectoryName(inputPath));

                    // Overwrite the original file with the cropped image.
                    emfImage.Save(inputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}