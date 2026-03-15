using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Cdr;

class CdrToPsdConverter
{
    static void Main()
    {
        // Path to the source CDR file
        string inputCdrPath = @"C:\Temp\sample.cdr";

        // Desired output PSD file path
        string outputPsdPath = @"C:\Temp\sample_converted.psd";

        // Load the CDR image (vector or multipage)
        using (Image cdrImage = Image.Load(inputCdrPath))
        {
            // Prepare PSD export options
            var psdOptions = new PsdOptions();

            // If the source is a vector image, configure rasterization options
            if (cdrImage is VectorImage vectorImg)
            {
                // Obtain default rasterization options based on the source size and background color
                psdOptions.VectorRasterizationOptions = (VectorRasterizationOptions)vectorImg.GetDefaultOptions(
                    new object[] { Color.White, cdrImage.Width, cdrImage.Height });

                // Set rendering preferences for crisp vector conversion
                psdOptions.VectorRasterizationOptions.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
                psdOptions.VectorRasterizationOptions.SmoothingMode = SmoothingMode.None;
            }

            // If the source is multipage, export selected pages as separate PSD layers
            if (cdrImage is IMultipageImage multiPageImg && multiPageImg.PageCount > 2)
            {
                // Export the first two pages (0 and 1) as layers
                psdOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, 2));
            }

            // Save the image as PSD using the configured options
            cdrImage.Save(outputPsdPath, psdOptions);
        }
    }
}