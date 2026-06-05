using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class SimpleSvgCallback : SvgResourceKeeperCallback
{
    private readonly string _outputPath;

    public SimpleSvgCallback(string outputPath)
    {
        _outputPath = outputPath;
    }

    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        string svgContent = System.Text.Encoding.UTF8.GetString(htmlData);

        // Insert a simple CSS style block after the opening <svg> tag
        int insertPos = svgContent.IndexOf('>');
        if (insertPos != -1)
        {
            string css = "\n<style type=\"text/css\">svg {font-family: Arial, sans-serif;}</style>\n";
            svgContent = svgContent.Insert(insertPos + 1, css);
        }

        File.WriteAllText(_outputPath, svgContent);
        return _outputPath;
    }
}

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
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

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for OTG
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure SVG save options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = otgRasterOptions,
                    TextAsShapes = true,
                    Callback = new SimpleSvgCallback(outputPath)
                };

                // Save as SVG (the callback will embed CSS)
                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}