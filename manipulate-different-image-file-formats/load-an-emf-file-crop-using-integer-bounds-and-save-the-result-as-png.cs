using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.emf";
        string outputPath = "output.png";

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

            // Load the EMF image
            using (EmfImage emf = (EmfImage)Image.Load(inputPath))
            {
                // Define crop rectangle (example values)
                int x = 10;
                int y = 10;
                int width = 200;
                int height = 150;
                Rectangle cropRect = new Rectangle(x, y, width, height);

                // Crop the image
                emf.Crop(cropRect);

                // Save as PNG
                PngOptions pngOptions = new PngOptions();
                emf.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}