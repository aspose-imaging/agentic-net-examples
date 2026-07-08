using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class ExternalResourceKeeper : SvgResourceKeeperCallback
{
    private readonly string _svgPath;

    public ExternalResourceKeeper(string svgPath)
    {
        _svgPath = svgPath;
    }

    // Save image resources as external files and return a relative path
    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType,
        string suggestedFileName, ref bool useEmbeddedImage)
    {
        // Force external storage
        useEmbeddedImage = false;

        // Create a folder named "resources" next to the SVG file
        string resourcesDir = Path.Combine(Path.GetDirectoryName(_svgPath) ?? string.Empty, "resources");
        Directory.CreateDirectory(resourcesDir);

        // Write the image data to a file
        string resourceFilePath = Path.Combine(resourcesDir, suggestedFileName);
        File.WriteAllBytes(resourceFilePath, imageData);

        // Return a relative path that will be used inside the SVG
        return $"resources/{suggestedFileName}";
    }

    // Called when the SVG document is ready; write it to the target location
    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        // Ensure the directory exists
        string dir = Path.GetDirectoryName(suggestedFileName);
        if (!string.IsNullOrEmpty(dir))
        {
            Directory.CreateDirectory(dir);
        }

        // Write the SVG data
        File.WriteAllBytes(suggestedFileName, htmlData);

        // Return the path that was used
        return suggestedFileName;
    }
}

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\output.svg";

        // Verify the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

        try
        {
            // Load the metafile
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG export options
                var svgOptions = new SvgOptions
                {
                    // Use the custom callback to store external resources
                    Callback = new ExternalResourceKeeper(outputPath),

                    // Set rasterization options (page size matches the source image)
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                // Save as SVG; external images will be written by the callback
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
 * 1. When a developer needs to convert Windows Metafile (EMF) graphics into scalable SVG files while storing embedded bitmap resources as separate image files for efficient web delivery.
 * 2. When an application must generate SVG assets for a design system and keep large raster images in a “resources” folder to reduce SVG size and improve browser caching.
 * 3. When a reporting tool exports charts as EMF and then transforms them into SVG for interactive dashboards, requiring external PNG/JPEG resources to be referenced via relative paths.
 * 4. When a document conversion service processes legacy vector files and wants to preserve image fidelity by saving the SVG with external image files that can be edited independently.
 * 5. When a CI/CD pipeline automates asset preparation for responsive web pages, converting EMF logos to SVG and separating image resources so designers can replace them without modifying the SVG markup.
 */