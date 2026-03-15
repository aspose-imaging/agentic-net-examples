using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats;

// Example: Apply gamma correction to an image using Aspose.Imaging
class GammaCorrectionExample
{
    static void Main()
    {
        // Input image path (any supported raster format, e.g., PNG, JPEG, BMP)
        string inputPath = @"c:\temp\sample.png";

        // Output paths for the results
        string outputPathUniform = @"c:\temp\sample.GammaUniform.png";
        string outputPathSeparate = @"c:\temp\sample.GammaSeparate.png";

        // Load the image using the Aspose.Imaging lifecycle rule
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage which provides the AdjustGamma methods
            RasterImage rasterImage = (RasterImage)image;

            // -------------------------------------------------
            // 1. Apply the same gamma coefficient to all channels
            // -------------------------------------------------
            // Gamma value > 1 brightens the image, < 1 darkens it
            rasterImage.AdjustGamma(2.0f); // uniform gamma for R, G, B

            // Save the result (using default options for the original format)
            rasterImage.Save(outputPathUniform);

            // -------------------------------------------------
            // 2. Apply individual gamma coefficients per channel
            // -------------------------------------------------
            // Example values: red=1.2, green=2.5, blue=3.0
            rasterImage.AdjustGamma(1.2f, 2.5f, 3.0f);

            // Save the result (again using default options)
            rasterImage.Save(outputPathSeparate);
        }

        Console.WriteLine("Gamma correction completed.");
    }
}