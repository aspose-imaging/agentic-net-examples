using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // ------------------------------------------------------------
        // Prerequisites:
        // 1. Add reference to Aspose.Imaging for .NET (NuGet package: Aspose.Imaging)
        // 2. If you have a license, set it before loading images:
        //    Aspose.Imaging.License license = new Aspose.Imaging.License();
        //    license.SetLicense("Aspose.Imaging.lic");
        // ------------------------------------------------------------

        // Path to the raster image you want to convert (any supported raster format)
        string rasterPath = "sample.png";

        // Desired output SVG file path
        string svgPath = "sample.svg";

        // Load the raster image using the unified Image.Load method.
        // This method supports all raster formats that Aspose.Imaging can read.
        using (Image rasterImage = Image.Load(rasterPath))
        {
            // Ensure the loaded image is a raster image (not already a vector image).
            if (rasterImage is RasterImage)
            {
                // ------------------------------------------------------------
                // 1. Create rasterization options.
                //    PageSize is set to the original image size to keep dimensions.
                // ------------------------------------------------------------
                VectorRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = rasterImage.Size
                };

                // ------------------------------------------------------------
                // 2. Configure SVG save options.
                //    - VectorRasterizationOptions links the rasterization settings.
                //    - Compress = false produces plain SVG (set true for SVGZ).
                //    - TextAsShapes = false keeps text as <text> elements.
                // ------------------------------------------------------------
                SvgOptions svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterizationOptions,
                    Compress = false,
                    TextAsShapes = false
                };

                // ------------------------------------------------------------
                // 3. Save the raster image as SVG using the save rule.
                // ------------------------------------------------------------
                rasterImage.Save(svgPath, svgOptions);
                Console.WriteLine($"Conversion successful: {svgPath}");
            }
            else
            {
                Console.WriteLine("The loaded file is not a raster image and cannot be rasterized to SVG.");
            }
        }

        // ------------------------------------------------------------
        // Supported raster input extensions for SVG conversion.
        // This list reflects the formats that Aspose.Imaging can load
        // and subsequently rasterize to SVG.
        // ------------------------------------------------------------
        string[] supportedRasterFormats = new[]
        {
            ".bmp", ".gif", ".jpeg", ".jpg", ".png", ".tiff", ".tif",
            ".webp", ".ico", ".psd", ".psb", ".pdf"
        };

        Console.WriteLine("Supported raster input extensions for SVG conversion:");
        foreach (string ext in supportedRasterFormats)
        {
            Console.WriteLine(ext);
        }
    }
}