using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input file paths
        string jpgPath = "input.jpg";
        string otgPath = "template.otg";
        string outputPath = "merged.png";

        // Load the JPEG image as a raster image
        using (RasterImage jpgImage = (RasterImage)Image.Load(jpgPath))
        {
            // Load the OTG template image
            using (Image otgImage = Image.Load(otgPath))
            {
                // Prepare the output source
                Source outputSource = new FileCreateSource(outputPath, false);

                // Configure PNG options with vector rasterization for OTG
                PngOptions pngOptions = new PngOptions()
                {
                    Source = outputSource,
                    VectorRasterizationOptions = new OtgRasterizationOptions()
                };
                ((OtgRasterizationOptions)pngOptions.VectorRasterizationOptions).PageSize = otgImage.Size;

                // Create a PNG canvas sized to the OTG template
                using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, otgImage.Width, otgImage.Height))
                {
                    // Draw the JPEG onto the canvas at the top-left corner
                    Rectangle destRect = new Rectangle(0, 0, jpgImage.Width, jpgImage.Height);
                    canvas.SaveArgb32Pixels(destRect, jpgImage.LoadArgb32Pixels(jpgImage.Bounds));

                    // Save the merged image (the canvas is already bound to the output file)
                    canvas.Save();
                }
            }
        }
    }
}