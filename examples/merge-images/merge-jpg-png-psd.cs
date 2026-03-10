using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class MergeJpgToPngViaPsd
{
    static void Main()
    {
        // Define the folder where the images are located
        string dir = @"C:\temp\";

        // Load the source JPG image
        using (Image jpgImage = Image.Load(dir + "source.jpg"))
        {
            // Create PSD save options (default settings)
            PsdOptions psdOptions = new PsdOptions();

            // Save the JPG image as a PSD file
            jpgImage.Save(dir + "intermediate.psd", psdOptions);
        }

        // Load the intermediate PSD image
        using (Image psdImage = Image.Load(dir + "intermediate.psd"))
        {
            // Create PNG save options (default settings)
            PngOptions pngOptions = new PngOptions();

            // Save the PSD image as a PNG file – this merges the original JPG into PNG via PSD
            psdImage.Save(dir + "merged.png", pngOptions);
        }
    }
}