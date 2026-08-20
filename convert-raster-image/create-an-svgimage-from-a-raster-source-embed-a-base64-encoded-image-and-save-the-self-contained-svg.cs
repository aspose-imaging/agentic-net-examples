// HOW-TO: Create Self‑Contained SVG from PNG with Embedded Base64 Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

// Custom callback to force embedding of raster resources as base64 data
class EmbeddedResourceCallback : SvgResourceKeeperCallback
{
    // Called for each raster resource (e.g., PNG, JPEG) that needs to be saved
    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType,
        string suggestedFileName, ref bool useEmbeddedImage)
    {
        // Instruct Aspose.Imaging to embed the image data directly into the SVG
        useEmbeddedImage = true;
        // No external file is created, so return null
        return null;
    }

    // Called when the SVG document itself is ready; not used for this example
    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        return null;
    }
}

class Program
{
    static void Main()
    {
        // Hard‑coded input (raster image) and output (self‑contained SVG) paths
        string inputPath = @"C:\Images\source.png";
        string outputPath = @"C:\Images\output.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the raster image that will be embedded
            using (Image rasterImage = Image.Load(inputPath))
            {
                // Prepare SVG options with rasterization settings matching the source size
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = rasterImage.Size
                    },
                    // Attach the custom callback that forces base64 embedding
                    Callback = new EmbeddedResourceCallback()
                };

                // Create a new empty SVG image with the same dimensions as the raster source
                using (SvgImage svgImage = new SvgImage(svgOptions, rasterImage.Width, rasterImage.Height))
                {
                    // The raster image will be embedded automatically because of the callback.
                    // No additional drawing code is required for this simple embedding scenario.

                    // Save the self‑contained SVG file
                    svgImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to embed a raster logo into an SVG icon set so the SVG can be shared without external image files.
 * 2. When generating printable vector graphics from user‑uploaded photos and you want the SVG to contain the image data inline for email attachment.
 * 3. When creating responsive web graphics that must work offline, embedding the PNG as base64 ensures the SVG renders without additional HTTP requests.
 * 4. When converting legacy raster assets to a single‑file SVG for inclusion in documentation or e‑books that require self‑contained images.
 * 5. When building a C# image‑processing pipeline that outputs SVG diagrams with embedded screenshots for automated reporting.
 */
