using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\sample_cropped.gif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CorelDRAW (CDR) image
        using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
        {
            // Define a 200x200 rectangle (top‑left corner at (0,0))
            Rectangle cropArea = new Rectangle(0, 0, 200, 200);

            // Crop the image to the defined rectangle
            cdrImage.Crop(cropArea);

            // Save the cropped image as GIF
            GifOptions gifOptions = new GifOptions();
            cdrImage.Save(outputPath, gifOptions);
        }
    }
}