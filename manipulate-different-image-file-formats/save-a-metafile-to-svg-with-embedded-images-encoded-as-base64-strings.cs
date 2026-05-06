using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Base64SvgResourceKeeperCallback : SvgResourceKeeperCallback
{
    // Called when an image resource is ready. We embed the image as a Base64 data URI.
    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType, string suggestedFileName, ref bool useEmbeddedImage)
    {
        useEmbeddedImage = true; // Request embedding.

        string mime;
        switch (imageType)
        {
            case SvgImageType.Png:
                mime = "image/png";
                break;
            case SvgImageType.Jpeg:
                mime = "image/jpeg";
                break;
            case SvgImageType.Gif:
                mime = "image/gif";
                break;
            case SvgImageType.Bmp:
                mime = "image/bmp";
                break;
            case SvgImageType.Tiff:
                mime = "image/tiff";
                break;
            default:
                mime = "application/octet-stream";
                break;
        }

        string base64 = Convert.ToBase64String(imageData);
        // Return a data URI that will be placed directly into the SVG.
        return $"data:{mime};base64,{base64}";
    }

    // Called when the SVG document is ready. We simply return the suggested file name.
    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        // No additional processing needed; return the suggested name.
        return suggestedFileName;
    }
}

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths.
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\output.svg";

        // Input file existence check.
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists.
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the metafile.
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG export options with a callback that embeds images as Base64.
                var svgOptions = new SvgOptions
                {
                    Callback = new Base64SvgResourceKeeperCallback(),
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                // Save as SVG with embedded resources.
                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}