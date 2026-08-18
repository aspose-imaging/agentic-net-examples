// HOW-TO: Save EMF as SVG with External Image Resources in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class ExternalResourceCallback : SvgResourceKeeperCallback
{
    private readonly string _svgOutputPath;

    public ExternalResourceCallback(string svgOutputPath)
    {
        _svgOutputPath = svgOutputPath;
    }

    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType, string suggestedFileName, ref bool useEmbeddedImage)
    {
        // Save external image files in a "resources" folder next to the SVG.
        string resourcesDir = Path.Combine(Path.GetDirectoryName(_svgOutputPath) ?? string.Empty, "resources");
        Directory.CreateDirectory(resourcesDir);

        string fileName = string.IsNullOrEmpty(suggestedFileName)
            ? $"image_{Guid.NewGuid()}{GetExtension(imageType)}"
            : suggestedFileName;

        string fullPath = Path.Combine(resourcesDir, fileName);
        File.WriteAllBytes(fullPath, imageData);

        // Return a relative path that will be written into the SVG.
        return Path.Combine("resources", fileName).Replace('\\', '/');
    }

    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        // Default handling – let Aspose save the SVG normally.
        return null;
    }

    private string GetExtension(SvgImageType type)
    {
        return type switch
        {
            SvgImageType.Png => ".png",
            SvgImageType.Jpeg => ".jpg",
            SvgImageType.Gif => ".gif",
            SvgImageType.Bmp => ".bmp",
            SvgImageType.Tiff => ".tiff",
            _ => ".bin",
        };
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths.
            string inputPath = @"C:\Images\sample.emf";
            string outputPath = @"C:\Images\output.svg";

            // Verify input file existence.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists.
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Load the metafile.
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG export options with external resource callback.
                var svgOptions = new SvgOptions
                {
                    Callback = new ExternalResourceCallback(outputPath)
                };

                // Provide rasterization options for vector images.
                if (image is VectorImage)
                {
                    svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };
                }

                // Save as SVG; external images will be stored separately.
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
 * 1. When you need to convert a Windows Metafile (EMF) to a scalable SVG while extracting embedded bitmap images into separate files for easier editing.
 * 2. When generating web‑ready SVG graphics and want raster images stored in a “resources” folder to reduce SVG size and enable browser caching.
 * 3. When building a batch conversion utility that processes many EMF files and must organize external images in a consistent directory structure alongside each SVG.
 * 4. When integrating Aspose.Imaging into a reporting system that outputs charts as SVG but requires the chart’s raster components to be saved as external PNG or JPEG files.
 * 5. When creating an automated archival workflow for vector drawings that must reference external image resources to meet design or compliance standards.
 */
