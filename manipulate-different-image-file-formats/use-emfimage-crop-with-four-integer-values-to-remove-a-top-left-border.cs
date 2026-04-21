using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\sample_cropped.png";

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
                // Cast to EmfImage to access the specific Crop overload
                EmfImage emfImage = (EmfImage)image;

                // Define border sizes to remove from the top-left corner
                int leftShift = 50;   // pixels to remove from the left side
                int rightShift = 0;   // no removal from the right side
                int topShift = 30;    // pixels to remove from the top side
                int bottomShift = 0;  // no removal from the bottom side

                // Crop the image using shift values
                emfImage.Crop(leftShift, rightShift, topShift, bottomShift);

                // Save the cropped image as PNG
                emfImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}