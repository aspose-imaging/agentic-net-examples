using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to EMF image type
            EmfImage emfImage = (EmfImage)image;

            // Determine central 400x400 rectangle
            int cropWidth = 400;
            int cropHeight = 400;
            int x = Math.Max(0, (emfImage.Width - cropWidth) / 2);
            int y = Math.Max(0, (emfImage.Height - cropHeight) / 2);
            var cropArea = new Rectangle(x, y, cropWidth, cropHeight);

            // Crop the image
            emfImage.Crop(cropArea);

            // Save as GIF
            emfImage.Save(outputPath, new GifOptions());
        }
    }
}