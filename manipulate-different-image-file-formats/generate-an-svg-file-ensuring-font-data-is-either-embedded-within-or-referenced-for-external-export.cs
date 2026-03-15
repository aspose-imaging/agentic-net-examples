using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Input vector image (EMF, WMF, etc.) and output SVG file paths
        string inputPath = "input.emf";
        string outputPath = "output.svg";

        // Load the source image using Aspose.Imaging.Image.Load (lifecycle rule)
        using (Image image = Image.Load(inputPath))
        {
            // Configure SVG export options
            var svgOptions = new SvgOptions
            {
                // Keep text as text so that fonts can be embedded (instead of converting to shapes)
                TextAsShapes = false,
                // Assign a callback that controls how fonts are stored
                Callback = new FontEmbeddingCallback()
            };

            // Set appropriate vector rasterization options based on source type
            if (image is EmfImage emfImage)
            {
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = emfImage.Size,
                    BackgroundColor = Color.White,
                    RenderMode = EmfRenderMode.Auto
                };
                svgOptions.VectorRasterizationOptions = rasterOptions;
            }
            else if (image is WmfImage wmfImage)
            {
                var rasterOptions = new WmfRasterizationOptions
                {
                    PageSize = wmfImage.Size,
                    BackgroundColor = Color.White,
                    RenderMode = WmfRenderMode.Auto
                };
                svgOptions.VectorRasterizationOptions = rasterOptions;
            }
            else
            {
                // Generic fallback for other vector images
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };
                svgOptions.VectorRasterizationOptions = rasterOptions;
            }

            // Save the image as SVG using the configured options (lifecycle rule)
            image.Save(outputPath, svgOptions);
        }
    }

    // Callback that forces fonts to be embedded in the SVG as base64 data
    private class FontEmbeddingCallback : SvgResourceKeeperCallback
    {
        public override void OnFontResourceReady(FontStoringArgs args)
        {
            // Embed fonts directly into the SVG file
            args.FontStoreType = FontStoreType.Embedded;
        }
    }
}