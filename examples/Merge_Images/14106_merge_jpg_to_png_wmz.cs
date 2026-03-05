using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG file path
        string inputJpgPath = "input.jpg";
        // Temporary WMZ (compressed WMF) file path
        string wmzPath = "temp.wmz";
        // Final PNG output file path
        string outputPngPath = "output.png";

        // Load the JPG image
        using (Image jpgImage = Image.Load(inputJpgPath))
        {
            // Prepare WMZ (compressed WMF) save options
            Source wmzSource = new FileCreateSource(wmzPath, false);
            WmfOptions wmfOptions = new WmfOptions()
            {
                Source = wmzSource,
                Compress = true,
                VectorRasterizationOptions = new WmfRasterizationOptions()
                {
                    PageSize = jpgImage.Size
                }
            };

            // Save the JPG as a compressed WMZ file
            jpgImage.Save(wmzPath, wmfOptions);
        }

        // Load the WMZ file
        using (Image wmzImage = Image.Load(wmzPath))
        {
            // Prepare PNG save options
            Source pngSource = new FileCreateSource(outputPngPath, false);
            PngOptions pngOptions = new PngOptions()
            {
                Source = pngSource
            };

            // Save the WMZ image as PNG
            wmzImage.Save(outputPngPath, pngOptions);
        }
    }
}