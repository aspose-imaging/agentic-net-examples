using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        // All runtime errors are caught and reported
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"templates\sample.txt";
            string outputPath = @"output\result.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists before any save operation
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Attempt to load the file as an image and handle load failures
            try
            {
                using (Image image = Image.Load(inputPath))
                {
                    // If loading succeeded, save the image to the output path
                    image.Save(outputPath);
                }
            }
            catch (ImageLoadException ile)
            {
                // Specific handling for non‑image files
                Console.Error.WriteLine($"Unable to load image: {ile.Message}");
                return;
            }
        }
        catch (Exception ex)
        {
            // Catch any other unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}