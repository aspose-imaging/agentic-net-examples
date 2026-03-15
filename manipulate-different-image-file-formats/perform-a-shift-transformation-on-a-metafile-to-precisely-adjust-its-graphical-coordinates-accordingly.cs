using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class MetafileShiftExample
{
    static void Main()
    {
        // Input and output file paths
        string inputFile = @"C:\Temp\input.emf";
        string outputFile = @"C:\Temp\output_shifted.emf";

        // Load the EMF metafile
        using (EmfImage emfImage = (EmfImage)Image.Load(inputFile))
        {
            // Create a recorder graphics object from the loaded image
            EmfRecorderGraphics2D graphics = EmfRecorderGraphics2D.FromEmfImage(emfImage);

            // Define the translation offsets (shift values)
            float offsetX = 20f; // shift right by 20 units
            float offsetY = 30f; // shift down by 30 units

            // Apply the translation to the graphics' world transform
            graphics.TranslateTransform(offsetX, offsetY);

            // Finish recording and obtain the transformed metafile
            using (EmfImage shiftedEmf = graphics.EndRecording())
            {
                // Save the shifted metafile to the output path
                shiftedEmf.Save(outputFile);
            }
        }
    }
}