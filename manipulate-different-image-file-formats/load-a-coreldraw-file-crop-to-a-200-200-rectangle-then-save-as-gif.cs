using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\sample.cdr";
        string outputPath = @"C:\Temp\output.gif";

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

            // Define a 200x200 rectangle (top-left corner at 0,0)
            Rectangle cropArea = new Rectangle(0, 0, 200, 200);

            // Crop the image
            cdrImage.Crop(cropArea);

            // Save as GIF
            GifOptions gifOptions = new GifOptions();
            cdrImage.Save(outputPath, gifOptions);
        }
    }
}