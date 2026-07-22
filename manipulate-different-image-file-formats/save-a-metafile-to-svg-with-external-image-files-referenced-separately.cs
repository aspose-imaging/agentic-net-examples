using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class MySvgResourceKeeperCallback : SvgResourceKeeperCallback
{
    private readonly string _outputPath;

    public MySvgResourceKeeperCallback(string outputPath)
    {
        _outputPath = outputPath;
    }

    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType,
        string suggestedFileName, ref bool useEmbeddedImage)
    {
        // Force external image file
        useEmbeddedImage = false;

        // Determine folder for external resources relative to the SVG output
        string resourcesDir = Path.Combine(Path.GetDirectoryName(_outputPath) ?? string.Empty, "resources");
        Directory.CreateDirectory(resourcesDir);

        // Save the image data to a file
        string filePath = Path.Combine(resourcesDir, suggestedFileName);
        File.WriteAllBytes(filePath, imageData);

        // Return the relative path that will be used inside the SVG
        string relativePath = Path.Combine("resources", suggestedFileName);
        // Use forward slashes for SVG compatibility
        return relativePath.Replace('\\', '/');
    }

    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        // No special handling needed for the SVG document itself
        return null;
    }
}

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.emf";
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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Load the metafile
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG export options with external resource handling
                var svgOptions = new SvgOptions
                {
                    Callback = new MySvgResourceKeeperCallback(outputPath),
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                // Save as SVG with external images
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
 * 1. When a developer needs to convert Windows Metafile (EMF) graphics into scalable SVG files for web publishing while keeping large raster elements as separate image resources to reduce SVG file size.
 * 2. When an application must generate SVG assets for responsive design and wants external PNG or JPEG resources stored in a dedicated folder to enable caching and independent updates.
 * 3. When a reporting tool exports charts as EMF and must embed them in SVG dashboards, separating bitmap images to comply with SVG security policies that disallow embedded base64 data.
 * 4. When a document conversion service processes legacy vector drawings and needs to preserve original image quality by saving embedded bitmap parts as external files referenced via relative paths.
 * 5. When a CI/CD pipeline automates asset preparation for a mobile app, converting EMF icons to SVG while storing their raster components as external resources to meet app bundle size constraints.
 */