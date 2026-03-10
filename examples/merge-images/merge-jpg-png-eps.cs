using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

class MergeJpgToPngViaEps
{
    static void Main()
    {
        // Load the source JPG image
        using (Image jpgImage = Image.Load("source.jpg"))
        {
            // Save the JPG image as an EPS file (this embeds a raster preview)
            var epsOptions = new EpsOptions(); // EPS saving options
            jpgImage.Save("intermediate.eps", epsOptions);
        }

        // Load the EPS file we just created
        using (EpsImage epsImage = (EpsImage)Image.Load("intermediate.eps"))
        {
            // Retrieve the embedded JPEG preview (Photoshop thumbnail) from the EPS
            Image preview = epsImage.GetPreviewImage(EpsPreviewFormat.PhotoshopThumbnail);

            // If a preview exists, save it as PNG
            if (preview != null)
            {
                preview.Save("merged.png", new PngOptions());
                preview.Dispose();
            }
            else
            {
                // Fallback: render the EPS to PNG using PostScript rendering
                var renderOptions = new PngOptions
                {
                    VectorRasterizationOptions = new EpsRasterizationOptions
                    {
                        PageWidth = epsImage.Width,
                        PageHeight = epsImage.Height,
                        PreviewToExport = EpsPreviewFormat.Default
                    }
                };
                epsImage.Save("merged.png", renderOptions);
            }
        }
    }
}