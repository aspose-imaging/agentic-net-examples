using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class MySvgResourceKeeperCallback : SvgResourceKeeperCallback
{
    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType, string suggestedFileName, ref bool useEmbeddedImage)
    {
        // Request embedding the image as Base64
        useEmbeddedImage = true;
        // No external file is needed
        return null;
    }

    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        // No special handling for the SVG document itself
        return null;
    }
}

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\sample.svg";

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

            // Load the metafile
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG options with embedded image callback
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