using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.emf";
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load EMF image, crop central 400x400 region, and save as GIF
        using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
        {
            const int targetWidth = 400;
            const int targetHeight = 400;

            // Calculate top-left corner for central crop
            int left = (emfImage.Width - targetWidth) / 2;
            int top = (emfImage.Height - targetHeight) / 2;

            // Adjust if source image is smaller than target size
            if (left < 0) left = 0;
            if (top < 0) top = 0;
            int cropWidth = Math.Min(targetWidth, emfImage.Width);
            int cropHeight = Math.Min(targetHeight, emfImage.Height);

            // Define cropping rectangle
            Rectangle cropRect = new Rectangle(left, top, cropWidth, cropHeight);

            // Perform cropping
            emfImage.Crop(cropRect);

            // Save the cropped image as GIF
            GifOptions gifOptions = new GifOptions();
            emfImage.Save(outputPath, gifOptions);
        }
    }
}