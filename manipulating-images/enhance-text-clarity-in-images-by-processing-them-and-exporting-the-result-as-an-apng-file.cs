using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class EnhanceTextClarityToApng
{
    static void Main()
    {
        // Input raster image (e.g., scanned document with text)
        string inputPath = "input.png";

        // Output animated PNG file
        string outputPath = "output.apng";

        // Load the source image as an ApngImage (Aspose.Imaging automatically detects format)
        using (ApngImage image = (ApngImage)Image.Load(inputPath))
        {
            // Enhance overall readability:
            // 1. Apply automatic brightness/contrast normalization.
            image.AutoBrightnessContrast();

            // 2. Slightly increase contrast to make text edges sharper.
            //    The value > 1.0f boosts contrast; adjust as needed.
            image.AdjustContrast(1.2f);

            // Save the processed image as an APNG.
            // Default ApngOptions are sufficient for a single‑frame APNG.
            var apngOptions = new ApngOptions();
            image.Save(outputPath, apngOptions);
        }
    }
}