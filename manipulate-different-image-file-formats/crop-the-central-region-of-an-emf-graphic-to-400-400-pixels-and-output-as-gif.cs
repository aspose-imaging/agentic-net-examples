using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.emf";
            string outputPath = @"C:\Images\sample_cropped.gif";

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
                // Cast to EmfImage to access Crop method
                EmfImage emfImage = (EmfImage)image;

                // Define the central 400x400 rectangle
                int cropWidth = 400;
                int cropHeight = 400;
                int left = (emfImage.Width - cropWidth) / 2;
                int top = (emfImage.Height - cropHeight) / 2;
                var cropArea = new Aspose.Imaging.Rectangle(left, top, cropWidth, cropHeight);

                // Crop the image
                emfImage.Crop(cropArea);

                // Save the cropped image as GIF
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