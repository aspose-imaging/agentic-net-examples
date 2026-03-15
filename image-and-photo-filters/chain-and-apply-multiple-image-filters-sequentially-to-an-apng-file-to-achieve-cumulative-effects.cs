using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageOptions;
using System.Drawing;   // for Rectangle if needed

class ApngFilterChain
{
    static void Main()
    {
        // Load an existing APNG file. The Image.Load method follows the required lifecycle rule.
        using (ApngImage apng = (ApngImage)Image.Load("input.apng"))
        {
            // -----------------------------------------------------------------
            // 1. Apply a brightness increase to every frame.
            //    AdjustBrightness works on the whole image (all frames) and
            //    returns the modified image, allowing further chaining.
            // -----------------------------------------------------------------
            apng.AdjustBrightness(30);   // increase brightness by 30 units

            // -----------------------------------------------------------------
            // 2. Increase contrast globally.
            // -----------------------------------------------------------------
            apng.AdjustContrast(1.2f);   // 20% more contrast

            // -----------------------------------------------------------------
            // 3. Apply gamma correction globally.
            // -----------------------------------------------------------------
            apng.AdjustGamma(0.85f);     // slightly darken via gamma

            // -----------------------------------------------------------------
            // 4. Convert the whole animation to grayscale.
            // -----------------------------------------------------------------
            apng.Grayscale();

            // -----------------------------------------------------------------
            // 5. If you need per‑frame fine‑tuning, iterate over the frames.
            //    Here we demonstrate an additional per‑frame filter (contrast).
            // -----------------------------------------------------------------
            foreach (ApngFrame frame in apng.Pages)
            {
                // Each frame is a RasterCachedImage, so the same filter methods are available.
                frame.AdjustContrast(1.1f);   // subtle extra contrast per frame
            }

            // -----------------------------------------------------------------
            // Save the processed APNG. The Save method follows the required lifecycle rule.
            // -----------------------------------------------------------------
            apng.Save("output.apng");
        }
    }
}