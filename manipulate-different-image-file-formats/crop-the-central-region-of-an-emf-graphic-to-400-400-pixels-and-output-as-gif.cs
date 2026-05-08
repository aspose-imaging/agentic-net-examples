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
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\sample_cropped.gif";

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
            using (Image image = Image.Load(inputPath))
            {
                // Cast to EmfImage to access EMF-specific methods
                EmfImage emfImage = (EmfImage)image;

                // Determine the central 400x400 rectangle
                int cropWidth = 400;
                int cropHeight = 400;
                int left = Math.Max(0, (emfImage.Width - cropWidth) / 2);
                int top = Math.Max(0, (emfImage.Height - cropHeight) / 2);
                var cropArea = new Rectangle(left, top, cropWidth, cropHeight);

                // Crop the image
                emfImage.Crop(cropArea);

                // Save as GIF
                var gifOptions = new GifOptions();
                emfImage.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}