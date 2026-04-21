using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

// Custom callback that forces embedding of raster resources as Base64 strings
class EmbeddedImageCallback : SvgResourceKeeperCallback
{
    // Called for each raster resource (e.g., bitmap) found during SVG export
    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType,
                                                string suggestedFileName, ref bool useEmbeddedImage)
    {
        // Instruct the exporter to embed the image data directly into the SVG
        useEmbeddedImage = true;
        // No external file is created, so return an empty relative path
        return string.Empty;
    }

    // Not used for this scenario, but must be overridden
    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        // Return empty because we let the main Save method handle the SVG file creation
        return string.Empty;
    }
}

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\sample.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the metafile (EMF/WMF) and convert it to SVG with embedded images
        using (Image image = Image.Load(inputPath))
        {
            // Prepare SVG export options
            var svgOptions = new SvgOptions
            {
                // Use the custom callback to embed raster resources as Base64
                Callback = new EmbeddedImageCallback(),

                // Configure rasterization (required for vector images)
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                }
            };

            // Save the image as SVG using the configured options
            image.Save(outputPath, svgOptions);
        }
    }
}