using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded directory containing EMF files
            string inputDirectory = @"C:\EmfImages";

            // Get all EMF files in the directory
            string[] emfFiles = Directory.GetFiles(inputDirectory, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the EMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to EmfImage to access cropping functionality
                    EmfImage emfImage = image as EmfImage;
                    if (emfImage == null)
                    {
                        Console.Error.WriteLine($"Unable to load EMF image: {inputPath}");
                        continue;
                    }

                    // Define cropping rectangle (e.g., 10 pixels inset from each side)
                    int left = 10;
                    int top = 10;
                    int width = Math.Max(0, emfImage.Width - left * 2);
                    int height = Math.Max(0, emfImage.Height - top * 2);
                    var cropRect = new Rectangle(left, top, width, height);

                    // Perform the crop
                    emfImage.Crop(cropRect);

                    // Ensure the output directory exists (same as input directory)
                    string outputDir = Path.GetDirectoryName(inputPath);
                    Directory.CreateDirectory(outputDir);

                    // Overwrite the original file with the cropped image
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