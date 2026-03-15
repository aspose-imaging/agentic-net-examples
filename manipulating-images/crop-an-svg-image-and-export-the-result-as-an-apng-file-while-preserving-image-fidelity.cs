using System;
using System.Drawing; // For Rectangle
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Apng;

class SvgToApngCrop
{
    static void Main()
    {
        // Input SVG file path
        string inputSvgPath = @"C:\Images\source.svg";

        // Output APNG file path (extension .png is used for APNG)
        string outputApngPath = @"C:\Images\cropped_output.png";

        // Define the rectangle area to keep after cropping
        // Example: keep a 200x200 area starting at (50,50)
        Rectangle cropRect = new Rectangle(50, 50, 200, 200);

        // Load the SVG image
        using (Image image = Image.Load(inputSvgPath))
        {
            // Cast to SvgImage to access vector-specific members
            SvgImage svgImage = (SvgImage)image;

            // Crop the SVG to the desired rectangle
            svgImage.Crop(cropRect);

            // Prepare rasterization options for vector to raster conversion
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Use the size of the cropped SVG as the raster size
                PageSize = svgImage.Size
            };

            // Configure APNG saving options (inherits from PngOptions)
            ApngOptions apngOptions = new ApngOptions
            {
                // Assign the rasterization options so the vector image is rasterized during save
                VectorRasterizationOptions = rasterOptions,

                // Optional: set default frame time (e.g., 500 ms) for the APNG
                DefaultFrameTime = 500
            };

            // Save the cropped SVG as an APNG file
            svgImage.Save(outputApngPath, apngOptions);
        }
    }
}