using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageOptions;

class ApplyFilterToApng
{
    static void Main()
    {
        // Load the existing APNG file
        using (Image image = Image.Load("input.apng"))
        {
            // Cast to ApngImage to access frame collection
            ApngImage apng = (ApngImage)image;

            // Define the rectangle covering the whole frame
            var fullRect = new System.Drawing.Rectangle(0, 0, apng.Width, apng.Height);

            // Iterate over each frame (page) and apply a grayscale filter
            // The Grayscale method is applied to the whole image, but we can also use Filter with specific options.
            // Here we use the built‑in Grayscale method for simplicity.
            foreach (var page in apng.Pages)
            {
                // Each page is an ApngFrame which derives from RasterCachedImage,
                // so we can call Grayscale directly.
                ((ApngFrame)page).Grayscale();
            }

            // Save the modified APNG, preserving animation frames and timing
            apng.Save("output_filtered.apng");
        }
    }
}