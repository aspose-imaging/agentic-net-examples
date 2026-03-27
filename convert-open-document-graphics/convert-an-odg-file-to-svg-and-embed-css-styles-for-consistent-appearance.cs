using System;
using System.IO;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class CustomSvgCallback : SvgResourceKeeperCallback
{
    // Insert a simple CSS block into the generated SVG content.
    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        string svgContent = Encoding.UTF8.GetString(htmlData);
        const string css = "<style type=\"text/css\">svg {font-family: Arial;}</style>";

        int insertPos = svgContent.IndexOf('>');
        if (insertPos != -1)
        {
            // Insert CSS right after the opening <svg> tag.
            svgContent = svgContent.Insert(insertPos + 1, css);
        }

        // Ensure the output directory exists.
        string outputDir = Path.GetDirectoryName(suggestedFileName);
        if (!string.IsNullOrEmpty(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Write the modified SVG to the suggested file name.
        File.WriteAllText(suggestedFileName, svgContent, Encoding.UTF8);
        return suggestedFileName;
    }
}

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths.
        string inputPath = @"C:\Data\sample.odg";
        string outputPath = @"C:\Data\sample.svg";

        // Verify that the input file exists.
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists before saving.
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image.
        using (Image image = Image.Load(inputPath))
        {
            // Prepare SVG export options.
            var svgOptions = new SvgOptions
            {
                // Use a callback to embed CSS into the SVG.
                Callback = new CustomSvgCallback()
            };

            // Configure vector rasterization options (page size, etc.).
            var vectorOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };
            svgOptions.VectorRasterizationOptions = vectorOptions;

            // Save the image as SVG. The callback will handle CSS injection.
            image.Save(outputPath, svgOptions);
        }
    }
}