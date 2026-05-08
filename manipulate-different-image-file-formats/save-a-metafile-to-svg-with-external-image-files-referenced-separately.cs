using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class MySvgResourceKeeperCallback : SvgResourceKeeperCallback
{
    private readonly string _outputDirectory;

    public MySvgResourceKeeperCallback(string outputDirectory)
    {
        _outputDirectory = outputDirectory;
    }

    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType,
        string suggestedFileName, ref bool useEmbeddedImage)
    {
        // Force external image usage
        useEmbeddedImage = false;

        // Ensure the output directory exists (already created in Main, but safe here)
        Directory.CreateDirectory(_outputDirectory);

        string imagePath = Path.Combine(_outputDirectory, suggestedFileName);
        File.WriteAllBytes(imagePath, imageData);

        // Return relative path (just the file name)
        return suggestedFileName;
    }

    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        // This method is called when the SVG document is ready.
        // The document is already being saved by Image.Save, so we just return the file name.
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

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG options with a callback for external resources
                var svgOptions = new SvgOptions
                {
                    Callback = new MySvgResourceKeeperCallback(Path.GetDirectoryName(outputPath)),
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                // Save the Metafile as SVG with external image resources
                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}