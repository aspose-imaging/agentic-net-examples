using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\sample.cdr";
            string outputPath = "C:\\temp\\sample_cropped.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CorelDRAW file
            using (Image image = Image.Load(inputPath))
            {
                // Cast to CdrImage to access vector-specific methods
                CdrImage cdrImage = (CdrImage)image;

                // Define a 200×200 rectangle (top‑left corner)
                var cropRect = new Rectangle(0, 0, 200, 200);

                // Crop the image
                cdrImage.Crop(cropRect);

                // Save the cropped image as GIF
                var gifOptions = new GifOptions();
                cdrImage.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}