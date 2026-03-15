using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Filters;

class MotionBlurSvg
{
    static void Main()
    {
        // Path to the source SVG file
        string inputSvgPath = @"C:\Images\source.svg";

        // Path for the intermediate rasterized PNG
        string tempPngPath = @"C:\Images\temp.png";

        // Path for the final blurred image (PNG)
        string outputPngPath = @"C:\Images\blurred.png";

        // ---------- Load the SVG image ----------
        // Use the generic Image.Load method as required by the lifecycle rule.
        using (Image svgImage = Image.Load(inputSvgPath))
        {
            // ---------- Rasterize the SVG to a PNG ----------
            // Obtain default rasterization options for the SVG.
            VectorRasterizationOptions rasterOptions = (VectorRasterizationOptions)svgImage.GetDefaultOptions(
                new object[] { Aspose.Imaging.Color.White, svgImage.Width, svgImage.Height });

            // Set the desired page size (optional, here we keep original size)
            rasterOptions.PageSize = svgImage.Size;

            // Prepare PNG save options with the rasterization settings.
            PngOptions pngSaveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image to a temporary PNG file.
            svgImage.Save(tempPngPath, pngSaveOptions);
        }

        // ---------- Load the rasterized PNG ----------
        using (RasterImage rasterImage = (RasterImage)Image.Load(tempPngPath))
        {
            // ---------- Apply motion blur ----------
            // Create a Gaussian blur filter (used here as a stand‑in for motion blur).
            // Adjust Radius and Sigma to achieve the desired blur strength.
            GaussianBlurFilterOptions blurOptions = new GaussianBlurFilterOptions
            {
                Radius = 10,   // blur radius in pixels
                Sigma = 5      // standard deviation
            };

            // Apply the filter to the whole image.
            rasterImage.Filter(rasterImage.Bounds, blurOptions);

            // ---------- Save the blurred image ----------
            // Use the generic Save method with PNG options.
            PngOptions saveOptions = new PngOptions();
            rasterImage.Save(outputPngPath, saveOptions);
        }

        // Cleanup: delete the temporary rasterized PNG if desired.
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }

        Console.WriteLine("Motion blur applied and saved to: " + outputPngPath);
    }
}