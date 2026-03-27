using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class MySvgResourceKeeperCallback : SvgResourceKeeperCallback
{
    private readonly string _baseOutputDir;

    public MySvgResourceKeeperCallback(string baseOutputDir)
    {
        _baseOutputDir = baseOutputDir;
    }

    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType,
        string suggestedFileName, ref bool useEmbeddedImage)
    {
        // Save the image data to an external file and return a relative path.
        string resourcesDir = Path.Combine(_baseOutputDir, "resources");
        Directory.CreateDirectory(resourcesDir); // Ensure the directory exists.

        string filePath = Path.Combine(resourcesDir, suggestedFileName);
        File.WriteAllBytes(filePath, imageData);

        useEmbeddedImage = false; // Force external reference.
        return Path.Combine("resources", suggestedFileName).Replace('\\', '/');
    }

    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        // Not used in this scenario; return the suggested file name.
        return suggestedFileName;
    }
}

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths.
        string inputPath = @"C:\Input\sample.emf";
        string outputPath = @"C:\Output\sample.svg";

        // Verify input file existence.
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists.
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the metafile and save it as SVG with external resources.
        using (Image image = Image.Load(inputPath))
        {
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                },
                Callback = new MySvgResourceKeeperCallback(Path.GetDirectoryName(outputPath))
            };

            image.Save(outputPath, svgOptions);
        }
    }
}