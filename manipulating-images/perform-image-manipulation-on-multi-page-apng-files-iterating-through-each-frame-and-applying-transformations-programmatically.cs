using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Path to the source multi‑page APNG file
        string inputPath = "input.apng";

        // Path where the transformed APNG will be saved
        string outputPath = "output.apng";

        // Load the APNG image using the provided load rule
        using (ApngImage apngImage = (ApngImage)Image.Load(inputPath))
        {
            // Iterate through each frame (page) of the APNG
            for (int i = 0; i < apngImage.PageCount; i++)
            {
                // Cast the generic Image page to ApngFrame to access frame‑specific methods
                ApngFrame frame = (ApngFrame)apngImage.Pages[i];

                // Example transformation 1: increase brightness by 20 units
                frame.AdjustBrightness(20);

                // Example transformation 2: apply a gamma correction that varies per frame
                float gamma = 1.0f + i * 0.1f; // gradually increase gamma
                frame.AdjustGamma(gamma);
            }

            // Save the modified APNG using the provided save rule
            apngImage.Save(outputPath);
        }
    }
}