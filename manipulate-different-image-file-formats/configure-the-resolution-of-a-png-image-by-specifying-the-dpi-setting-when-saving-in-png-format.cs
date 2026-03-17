using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

// Define the directory containing the source image and the output location
string dir = @"c:\temp\";

// Load an existing PNG image
using (Image image = Image.Load(dir + "sample.png"))
{
    // Cast to PngImage to access PNG‑specific members
    PngImage pngImage = (PngImage)image;

    // Set the desired DPI (horizontal and vertical) for the image
    double dpiX = 300.0;
    double dpiY = 300.0;
    pngImage.SetResolution(dpiX, dpiY);

    // Prepare PNG save options and embed the same resolution settings
    PngOptions saveOptions = new PngOptions
    {
        ResolutionSettings = new ResolutionSetting(dpiX, dpiY)
    };

    // Save the image with the new DPI settings
    image.Save(dir + "sample_300dpi.png", saveOptions);
}