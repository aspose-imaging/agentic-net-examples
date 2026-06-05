using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class ExternalResourceCallback : SvgResourceKeeperCallback
{
    private readonly string _outputDirectory;

    public ExternalResourceCallback(string outputDirectory)
    {
        _outputDirectory = outputDirectory;
    }

    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType, string suggestedFileName, ref bool useEmbeddedImage)
    {
        // Force external resource
        useEmbeddedImage = false;

        // Ensure a subfolder for resources exists
        string resourcesFolder = Path.Combine(_outputDirectory, "resources");
        Directory.CreateDirectory(resourcesFolder);

        // Determine file name
        string fileName = !string.IsNullOrEmpty(suggestedFileName)
            ? suggestedFileName
            : $"image_{Guid.NewGuid()}{GetExtension(imageType)}";

        string fullPath = Path.Combine(resourcesFolder, fileName);
        File.WriteAllBytes(fullPath, imageData);

        // Return path relative to the SVG document
        return Path.Combine("resources", fileName).Replace('\\', '/');
    }

    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        // Not needed for external resources; just return the suggested name
        return suggestedFileName;
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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.emf";
            string outputPath = @"C:\Images\output.svg";

            // Verify input file exists
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
                // Configure SVG options with external resource callback
                var svgOptions = new SvgOptions
                {
                    Callback = new ExternalResourceCallback(Path.GetDirectoryName(outputPath))
                };

                // If the source is a vector image, set rasterization options (optional)
                if (image is VectorImage)
                {
                    svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };
                }

                // Save as SVG with external image resources
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
 * 1. When a developer needs to convert Windows Metafile (EMF) graphics into scalable SVG files while keeping large raster images as separate files to reduce SVG size for web delivery.
 * 2. When an application must generate SVG assets for a design system and store embedded bitmap resources in a dedicated resources folder to enable caching and independent updates.
 * 3. When a reporting tool exports charts as EMF and then converts them to SVG, using external PNG/JPEG files to comply with SVG specifications that disallow embedded binary data in certain environments.
 * 4. When a content management system processes user‑uploaded EMF logos and creates SVG versions that reference external image files, allowing editors to replace or edit those images without regenerating the SVG.
 * 5. When a CI/CD pipeline automates the conversion of legacy vector drawings to SVG and stores associated raster images separately to keep version control repositories lightweight and improve diff readability.
 */