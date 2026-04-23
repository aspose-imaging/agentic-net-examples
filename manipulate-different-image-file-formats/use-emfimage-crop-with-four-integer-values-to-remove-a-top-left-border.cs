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
        string outputPath = @"C:\Images\output\sample_cropped.png";

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
                // Cast to EmfImage to access EMF‑specific methods
                EmfImage emfImage = (EmfImage)image;

                // Define border sizes to remove (left, right, top, bottom)
                int leftShift = 10;   // remove 10 pixels from the left
                int rightShift = 0;   // keep right side unchanged
                int topShift = 10;    // remove 10 pixels from the top
                int bottomShift = 0;  // keep bottom side unchanged

                // Crop the image using shift values
                emfImage.Crop(leftShift, rightShift, topShift, bottomShift);

                // Save the cropped image as PNG
                PngOptions pngOptions = new PngOptions();
                emfImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}