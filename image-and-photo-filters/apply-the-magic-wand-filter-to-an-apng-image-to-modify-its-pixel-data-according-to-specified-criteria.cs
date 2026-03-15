using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.MagicWand;

class MagicWandApngExample
{
    static void Main()
    {
        // Paths to the input and output APNG files
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Load the APNG image; cast to RasterImage for MagicWand processing
        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            RasterImage raster = apng; // APNG derives from RasterImage

            // Define Magic Wand settings:
            // Reference point (50,30) and a tolerance threshold of 100
            var wandSettings = new MagicWandSettings(50, 30) { Threshold = 100 };

            // Create a mask based on the settings and apply it to the image
            MagicWandTool.Select(raster, wandSettings).Apply();

            // Save the modified APNG back to disk
            apng.Save(outputPath);
        }
    }
}