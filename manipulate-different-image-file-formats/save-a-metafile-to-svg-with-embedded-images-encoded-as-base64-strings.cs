using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class MySvgCallback : SvgResourceKeeperCallback
{
    // Embed image resources directly as Base64 strings.
    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType,
        string suggestedFileName, ref bool useEmbeddedImage)
    {
        useEmbeddedImage = true; // request embedding
        return null; // no external file needed
    }

    // No special handling for the SVG document itself.
    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        return null;
    }
}

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths.
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\sample.svg";

        // Verify input file existence.
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists.
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the metafile (EMF/WMF).
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG export with embedded resources.
                var svgOptions = new SvgOptions
                {
                    Callback = new MySvgCallback(),
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                // Save as SVG; images will be embedded as Base64.
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
 * 1. When a developer needs to convert Windows Metafile (EMF or WMF) graphics into a self‑contained SVG for inclusion in a web page without relying on external image files.
 * 2. When an application must embed raster images from a metafile directly into the SVG as Base64 strings to guarantee correct rendering in browsers that block external resources.
 * 3. When generating SVG assets for email newsletters where all images have to be inline to avoid attachment restrictions and improve deliverability.
 * 4. When creating portable documentation PDFs that embed SVG diagrams with embedded raster content, allowing the PDF generator to treat each SVG as a single resource.
 * 5. When building a C# batch‑processing tool that scans a folder of EMF files and outputs SVG files with embedded images to simplify asset management in a CI/CD pipeline.
 */