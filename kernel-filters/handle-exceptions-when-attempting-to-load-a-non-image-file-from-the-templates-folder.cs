using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Templates\sample.txt";          // Example non‑image file
        string outputPath = @"C:\Output\result.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Check whether the file can be loaded as an image
        bool canLoad = Image.CanLoad(inputPath);
        if (!canLoad)
        {
            Console.WriteLine($"The file cannot be loaded as an image: {inputPath}");
            return;
        }

        // Attempt to load the image and handle possible load exceptions
        try
        {
            using (Image image = Image.Load(inputPath))
            {
                // Perform a simple operation – for example, save the image as PNG
                image.Save(outputPath);
                Console.WriteLine($"Image successfully saved to: {outputPath}");
            }
        }
        catch (ImageLoadException ex)
        {
            Console.WriteLine($"Failed to load image: {ex.Message}");
        }
        catch (ImageException ex)
        {
            // Catch other Aspose.Imaging related exceptions
            Console.WriteLine($"Aspose.Imaging error: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Catch any unexpected exceptions
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}