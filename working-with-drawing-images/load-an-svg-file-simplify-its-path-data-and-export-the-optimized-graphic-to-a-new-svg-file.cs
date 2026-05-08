using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class MySvgCallback : SvgResourceKeeperCallback
{
    private readonly string _outputPath;

    public MySvgCallback(string outputPath)
    {
        _outputPath = outputPath;
    }

    // Called when the SVG document is ready for export.
    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        // Here you could parse and simplify the SVG path data.
        // For this example we simply write the received data unchanged.
        File.WriteAllBytes(_outputPath, htmlData);
        return _outputPath;
    }
}

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.svg";

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

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG save options with a custom callback
                var svgOptions = new SvgOptions
                {
                    Callback = new MySvgCallback(outputPath),
                    Compress = false // keep uncompressed for readability
                };

                // Save the optimized SVG
                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}