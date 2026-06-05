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

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Ensure the loaded image is a vector image
                if (image is VectorImage vectorImage)
                {
                    try
                    {
                        // Attempt to remove background; may fail if no recognizable vector shapes
                        vectorImage.RemoveBackground();
                    }
                    catch (Exception ex)
                    {
                        // Specific handling for background removal failure
                        Console.Error.WriteLine($"RemoveBackground failed: {ex.Message}");
                        // Continue without background removal
                    }

                    // Save the result as PNG
                    var pngOptions = new PngOptions();
                    vectorImage.Save(outputPath, pngOptions);
                }
                else
                {
                    Console.Error.WriteLine("The loaded file is not a vector image.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}