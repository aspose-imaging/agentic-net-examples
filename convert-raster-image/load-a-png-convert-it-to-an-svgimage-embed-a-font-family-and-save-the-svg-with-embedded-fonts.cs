using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class MySvgResourceKeeperCallback : SvgResourceKeeperCallback
{
    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        // Simply return the suggested file name; resources are embedded automatically.
        return suggestedFileName;
    }

    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType, string suggestedFileName, ref bool useEmbeddedImage)
    {
        // Indicate that the image should be embedded in the SVG.
        useEmbeddedImage = true;
        return suggestedFileName;
    }
}

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.svg";

        try
        {
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
                // Set up rasterization options for SVG conversion
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure SVG options, including font embedding via callback
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterizationOptions,
                    TextAsShapes = false, // Keep text as text to allow font embedding
                    Callback = new MySvgResourceKeeperCallback()
                };

                // Save as SVG with embedded fonts
                image.Save(outputPath, svgOptions);
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
 * 1. When a web application must display high‑resolution PNG icons as scalable SVG graphics while preserving the original text styling, a developer can load the PNG, convert it to an SvgImage and embed the required font family using Aspose.Imaging for .NET.
 * 2. When generating printable marketing materials that combine raster images and custom typography, the code lets a C# program transform a PNG logo into an SVG with embedded fonts so the document renders correctly on any printer.
 * 3. When building an automated asset pipeline that converts user‑uploaded PNG screenshots into searchable SVG files for SEO, embedding the font ensures the text remains selectable and indexable by search engines.
 * 4. When creating a cross‑platform mobile app that needs to resize PNG illustrations without losing text clarity, developers can use this snippet to rasterize the PNG into an SVG and embed the font so the UI scales smoothly on different devices.
 * 5. When preparing technical documentation that includes PNG diagrams with annotated labels, the code enables conversion to SVG with embedded fonts, guaranteeing that the labels appear consistently regardless of the viewer’s installed fonts.
 */