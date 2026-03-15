using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Filters;

class PngFilterExample
{
    static void Main()
    {
        // Define input and output paths
        string dir = @"c:\temp\";
        string inputPath = System.IO.Path.Combine(dir, "input.png");
        string outputPath = System.IO.Path.Combine(dir, "output.png");

        // Load the PNG image from a file using the provided constructor
        using (PngImage pngImage = new PngImage(inputPath))
        {
            // Define the rectangle that covers the whole image
            Rectangle rect = pngImage.Bounds;

            // Apply a Gaussian blur filter to the entire image using the Filter method
            // (FilterOptionsBase derived class)
            GaussianBlurFilterOptions blurOptions = new GaussianBlurFilterOptions(5); // radius = 5
            pngImage.Filter(rect, blurOptions);

            // Load the 32‑bit ARGB pixel data for further custom processing
            int[] argbPixels = pngImage.LoadArgb32Pixels(rect);

            // Example pixel manipulation: invert colors while preserving alpha
            for (int i = 0; i < argbPixels.Length; i++)
            {
                int argb = argbPixels[i];
                int a = (argb >> 24) & 0xFF;
                int r = 255 - ((argb >> 16) & 0xFF);
                int g = 255 - ((argb >> 8) & 0xFF);
                int b = 255 - (argb & 0xFF);
                argbPixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
            }

            // Write the modified pixel data back to the image
            pngImage.SaveArgb32Pixels(rect, argbPixels);

            // Save the processed image to a new file using the provided Save method
            pngImage.Save(outputPath);
        }
    }
}