using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.emf";
        string outputPath = @"C:\temp\output_shifted.emf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
        {
            // Create a recorder graphics object from the loaded image
            EmfRecorderGraphics2D graphics = EmfRecorderGraphics2D.FromEmfImage(emfImage);

            // Define the shift (translation) values
            float shiftX = 50f; // shift right by 50 units
            float shiftY = 30f; // shift down by 30 units

            // Apply the translation transform
            graphics.TranslateTransform(shiftX, shiftY);

            // End recording and obtain the transformed image
            using (EmfImage shiftedImage = graphics.EndRecording())
            {
                // Save the transformed image
                shiftedImage.Save(outputPath);
            }
        }
    }
}