using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class ApplySolidBackground
{
    static void Main()
    {
        // Load the PNG image that contains transparency
        using (Image image = Image.Load("input.png"))
        {
            // Cast to PngImage to access PNG‑specific members if needed
            PngImage png = (PngImage)image;

            // Define the solid background color you want to apply
            Color backgroundColor = Color.FromArgb(255, 0, 128, 255); // Example: opaque deep sky blue

            // Replace all non‑transparent pixels with the background color.
            // The original alpha values are preserved, giving a uniform color while keeping the existing transparency.
            png.ReplaceNonTransparentColors(backgroundColor);

            // Save the modified image
            png.Save("output.png");
        }
    }
}