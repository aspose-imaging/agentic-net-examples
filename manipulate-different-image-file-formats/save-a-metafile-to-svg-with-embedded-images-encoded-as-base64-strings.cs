using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class MySvgResourceKeeperCallback : SvgResourceKeeperCallback
{
    // Use embedded image data (Base64) for all image resources.
    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType,
        string suggestedFileName, ref bool useEmbeddedImage)
    {
        useEmbeddedImage = true;               // request embedding
        return null;                           // no external file needed
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
        // Hard‑coded paths
        string inputPath = @"C:\input\sample.emf";
        string outputPath = @"C:\output\sample.svg";

        try
        {
            // Verify input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the metafile
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG options with embedded resources
                var svgOptions = new SvgOptions
                {
                    Callback = new MySvgResourceKeeperCallback(),
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                // Save as SVG with embedded images (Base64)
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
 * 1. When a developer needs to convert Windows Metafile (EMF) drawings into web‑ready SVG files with all raster images embedded as Base64 strings to avoid external image dependencies.
 * 2. When a .NET application must generate a single‑file SVG report from legacy vector assets so that the output can be displayed in browsers or email clients without requiring separate image files.
 * 3. When an automated build pipeline processes design assets and requires embedding raster resources directly into the SVG to ensure consistent rendering across different operating systems.
 * 4. When a developer is creating a portable SVG export feature for a CAD or diagramming tool that must preserve the original image quality by rasterizing pages at the original size and embedding them in the SVG.
 * 5. When a cloud‑based service needs to store vector graphics in a database as a self‑contained SVG string, using Aspose.Imaging for .NET to embed all bitmap resources as Base64 to simplify retrieval and display.
 */