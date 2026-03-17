using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the vector file (e.g., CorelDRAW, SVG, etc.)
        string inputFileName = "test.cdr";

        // Load the vector image using Aspose.Imaging
        using (Image image = Image.Load(inputFileName))
        {
            // Cast to VectorImage to access vector-specific functionality
            VectorImage vectorImage = (VectorImage)image;

            // Retrieve all embedded raster images
            EmbeddedImage[] embeddedImages = vectorImage.GetEmbeddedImages();

            // Export each embedded image as a high‑quality PNG bitmap
            for (int i = 0; i < embeddedImages.Length; i++)
            {
                string outFileName = $"image{i}.png";

                // Each EmbeddedImage implements IDisposable, so wrap it in using
                using (EmbeddedImage embedded = embeddedImages[i])
                {
                    // Save the raster image preserving its original quality
                    embedded.Image.Save(outFileName, new PngOptions());
                }
            }
        }
    }
}