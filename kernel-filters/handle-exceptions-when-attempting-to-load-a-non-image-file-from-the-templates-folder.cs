using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"templates/nonImageFile.txt";
        string outputPath = @"output/result.png";

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

            // Attempt to load the file as an image
            Image image = null;
            try
            {
                image = Image.Load(inputPath);
            }
            catch (ImageLoadException ile)
            {
                // Handle non‑image file scenario
                Console.Error.WriteLine($"Unable to load image: {ile.Message}");
                return;
            }

            // If loading succeeded, save the image in PNG format
            using (image)
            {
                var options = new PngOptions();
                image.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}