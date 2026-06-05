using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.tif";
            string outputPath = @"C:\temp\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Save the image in a different format (PNG in this example)
                image.Save(outputPath);
            }

            // -----------------------------------------------------------------
            // Example: Create a new BMP image from scratch using BmpOptions
            // -----------------------------------------------------------------
            string newImagePath = @"C:\temp\newImage.bmp";

            // Ensure the directory for the new image exists
            Directory.CreateDirectory(Path.GetDirectoryName(newImagePath));

            // Configure BMP options and specify the file creation source
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(newImagePath, false) // false => not temporal, file will be saved
            };

            // Create a new image with the specified dimensions
            using (Image newImage = Image.Create(bmpOptions, 800, 600))
            {
                // Perform any drawing or processing here if needed

                // Save the newly created image (writes to newImagePath)
                newImage.Save();
            }

            Console.WriteLine("Conversion and creation completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}