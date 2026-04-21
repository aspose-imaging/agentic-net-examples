using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class MySvgResourceKeeperCallback : SvgResourceKeeperCallback
{
    private readonly string _resourceFolder;

    public MySvgResourceKeeperCallback(string resourceFolder)
    {
        _resourceFolder = resourceFolder ?? string.Empty;
    }

    // Save external image resources and return a relative path
    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType,
        string suggestedFileName, ref bool useEmbeddedImage)
    {
        // Ensure the folder exists (already handled by caller)
        string filePath = Path.Combine(_resourceFolder, suggestedFileName);
        File.WriteAllBytes(filePath, imageData);
        useEmbeddedImage = false; // force external reference
        return suggestedFileName; // relative path for SVG
    }

    // Save the final SVG document if needed (optional)
    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        string filePath = Path.Combine(_resourceFolder, suggestedFileName);
        File.WriteAllBytes(filePath, htmlData);
        return suggestedFileName;
    }
}

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\output.svg";

        // Input file existence check
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
            // Prepare SVG export options with external resource handling
            var svgOptions = new SvgOptions
            {
                Callback = new MySvgResourceKeeperCallback(Path.GetDirectoryName(outputPath)),
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                }
            };

            // Save as SVG; external images will be written by the callback
            image.Save(outputPath, svgOptions);
        }
    }
}