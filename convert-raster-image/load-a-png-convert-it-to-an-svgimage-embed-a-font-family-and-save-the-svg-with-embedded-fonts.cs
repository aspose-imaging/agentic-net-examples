using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare SVG save options
            SvgOptions svgOptions = new SvgOptions
            {
                // Keep text as text to embed fonts
                TextAsShapes = false,
                // Set rasterization options (page size matches source image)
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                },
                // Callback for handling embedded resources (fonts, images, etc.)
                Callback = new MySvgResourceKeeperCallback()
            };

            // Save as SVG with embedded fonts
            image.Save(outputPath, svgOptions);
        }
    }
}

// Custom callback to handle embedded resources during SVG export
class MySvgResourceKeeperCallback : SvgResourceKeeperCallback
{
    // Called when the SVG document is ready for export
    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        // Return the suggested file name (the caller will handle the actual saving)
        return suggestedFileName;
    }

    // Called when an image resource (e.g., embedded font) is ready for export
    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType, string suggestedFileName, ref bool useEmbeddedImage)
    {
        // Indicate that the resource should be embedded
        useEmbeddedImage = true;
        // Return the suggested file name (relative path) for the resource
        return suggestedFileName;
    }
}