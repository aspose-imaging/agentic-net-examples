using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output_cropped.emf";

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

            // Define the number of pixels to remove from each side
            int leftShift = 10;   // remove 10 pixels from the left
            int rightShift = 0;   // keep right side unchanged
            int topShift = 10;    // remove 10 pixels from the top
            int bottomShift = 0;  // keep bottom side unchanged

            // Crop the image
            emfImage.Crop(leftShift, rightShift, topShift, bottomShift);

            // Save the cropped image
            emfImage.Save(outputPath);
        }
    }
}