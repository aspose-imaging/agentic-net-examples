using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Ico;
using Aspose.Imaging.ImageOptions;

class MergeJpgToPngViaIco
{
    static void Main()
    {
        // Paths for source JPG and final PNG output
        string jpgPath = "input.jpg";
        string icoPath = "merged.ico";
        string pngPath = "output.png";

        // Load the JPG image as a raster image
        using (RasterImage jpgImage = (RasterImage)Image.Load(jpgPath))
        {
            // Create ICO options (default: PNG format, 32 bits per pixel)
            IcoOptions icoOptions = new IcoOptions();

            // Initialize a new ICO image with the same dimensions as the JPG
            using (IcoImage icoImage = new IcoImage(jpgImage.Width, jpgImage.Height, icoOptions))
            {
                // Add the JPG image as a page; Aspose.Imaging converts it to a 32‑bit PNG entry internally
                icoImage.AddPage(jpgImage);

                // Save the ICO file (contains the PNG‑converted page)
                icoImage.Save(icoPath);
            }
        }

        // Load the created ICO file and export its first page as a PNG image
        using (IcoImage icoImage = (IcoImage)Image.Load(icoPath))
        {
            // Save the first page (the only page we added) as a PNG file
            icoImage.Save(pngPath, new PngOptions());
        }
    }
}