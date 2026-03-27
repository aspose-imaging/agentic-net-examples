using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

// Custom callback to embed raster resources as Base64 strings in the SVG
class EmbeddedImageCallback : SvgResourceKeeperCallback
{
    // Called when an image resource (e.g., bitmap) is ready for export.
    // Setting useEmbeddedImage to true forces the resource to be embedded.
    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType,
                                                string suggestedFileName, ref bool useEmbeddedImage)
    {
        useEmbeddedImage = true;          // embed the image
        return null;                      // no external file path needed
    }

    // Called when the SVG document itself is ready.
    // Returning null lets Aspose.Imaging handle the default saving.
    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        return null;
    }
}

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\sample.svg";

        // Verify input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the metafile (EMF/WMF) and save it as SVG with embedded images
        using (Image image = Image.Load(inputPath))
        {
            // Prepare SVG options with a callback that embeds raster resources
            var svgOptions = new SvgOptions
            {
                Callback = new EmbeddedImageCallback()
            };

            // Optional: set rasterization options to match the source size
            if (image is VectorImage vectorImage)
            {
                svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = vectorImage.Size
                };
            }

            // Save the image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}