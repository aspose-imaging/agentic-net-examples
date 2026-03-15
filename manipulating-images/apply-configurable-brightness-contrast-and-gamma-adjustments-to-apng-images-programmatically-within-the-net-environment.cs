using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageOptions;

class ApngAdjustmentExample
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = @"C:\Images\sample.apng";
        string outputPath = @"C:\Images\sample_adjusted.apng";

        // Adjustable parameters
        int brightness = 30;          // Range depends on image, positive to increase, negative to decrease
        float contrast = 20.0f;       // Range [-100; 100], positive to increase contrast
        float gamma = 1.2f;           // Gamma coefficient (>0), 1.0 means no change

        // Load the APNG image using Aspose.Imaging's lifecycle method
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to ApngImage to access APNG‑specific methods
            ApngImage apng = (ApngImage)image;

            // Apply brightness adjustment
            apng.AdjustBrightness(brightness);

            // Apply contrast adjustment
            apng.AdjustContrast(contrast);

            // Apply gamma correction (same coefficient for R, G, B channels)
            apng.AdjustGamma(gamma);

            // Save the modified APNG back to disk using the standard Save method
            apng.Save(outputPath);
        }

        Console.WriteLine("APNG image has been adjusted and saved to: " + outputPath);
    }
}