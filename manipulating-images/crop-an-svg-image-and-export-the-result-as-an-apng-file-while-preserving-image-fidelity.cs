using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path
        string inputPath = "input.svg";
        // Output APNG file path
        string outputPath = "output.apng";

        // Define the crop rectangle (example values)
        Rectangle cropRect = new Rectangle(10, 10, 200, 200);

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to SvgImage to access vector-specific methods
            SvgImage svgImage = (SvgImage)image;

            // Crop the SVG image to the specified rectangle
            svgImage.Crop(cropRect);

            // Prepare APNG save options with rasterization settings
            using (ApngOptions apngOptions = new ApngOptions())
            {
                // Set the output source (file creation)
                apngOptions.Source = new FileCreateSource(outputPath, false);

                // Configure vector rasterization to preserve fidelity
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,          // Use the cropped size
                    BackgroundColor = Color.White      // Set background color if needed
                };

                apngOptions.VectorRasterizationOptions = rasterOptions;

                // Save the cropped SVG as an APNG file
                svgImage.Save(outputPath, apngOptions);
            }
        }
    }
}