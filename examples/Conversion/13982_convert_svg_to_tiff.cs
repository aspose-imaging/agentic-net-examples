using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class SvgToTiffConverter
{
    static void Main()
    {
        // Path to the source SVG file
        string inputSvgPath = @"C:\Images\source.svg";

        // Desired output TIFF file path
        string outputTiffPath = @"C:\Images\converted.tif";

        // Load the SVG image using Aspose.Imaging's unified loader
        using (Image svgImage = Image.Load(inputSvgPath))
        {
            // Obtain default rasterization options for the vector image.
            // The options include page size, background color, etc.
            var rasterOptions = (VectorRasterizationOptions)svgImage.GetDefaultOptions(
                new object[] { Aspose.Imaging.Color.White, svgImage.Width, svgImage.Height });

            // Create TIFF save options with the default expected format.
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                // Assign the rasterization options so the SVG is rasterized during save.
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as TIFF.
            svgImage.Save(outputTiffPath, tiffOptions);
        }
    }
}