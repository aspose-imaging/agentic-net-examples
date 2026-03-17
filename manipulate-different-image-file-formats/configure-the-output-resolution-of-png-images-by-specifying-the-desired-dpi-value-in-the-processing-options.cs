using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class ConfigurePngResolution
{
    static void Main()
    {
        // Path to the folder containing the source image
        string dir = @"C:\temp\";

        // Load an existing PNG image
        using (Image image = Image.Load(dir + "sample.png"))
        {
            // Create PNG save options
            PngOptions pngOptions = new PngOptions();

            // Set desired horizontal and vertical DPI (e.g., 300 DPI)
            pngOptions.ResolutionSettings = new ResolutionSetting(300.0, 300.0);

            // Save the image with the specified DPI
            image.Save(dir + "sample_300dpi.png", pngOptions);
        }
    }
}