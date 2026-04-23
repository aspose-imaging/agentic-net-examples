using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.cdr";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Check if the loaded image is a vector image
                if (!(image is VectorImage vectorImage))
                {
                    Console.Error.WriteLine("The provided file is not a vector image.");
                    return;
                }

                // Attempt to remove the background
                try
                {
                    vectorImage.RemoveBackground();
                }
                catch (Exception ex)
                {
                    // Handle cases where background removal fails (e.g., no recognizable vector shapes)
                    Console.Error.WriteLine($"Background removal failed: {ex.Message}");
                    // Continue without background removal
                }

                // Save the result as a raster image (PNG)
                var pngOptions = new PngOptions();
                vectorImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}