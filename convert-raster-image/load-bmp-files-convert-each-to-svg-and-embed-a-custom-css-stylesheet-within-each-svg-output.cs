using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class CssEmbeddingCallback : SvgResourceKeeperCallback
{
    private readonly string _css;

    public CssEmbeddingCallback(string css)
    {
        _css = css;
    }

    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        string svgContent = System.Text.Encoding.UTF8.GetString(htmlData);
        int insertPos = svgContent.IndexOf('>');
        if (insertPos != -1)
        {
            string before = svgContent.Substring(0, insertPos + 1);
            string after = svgContent.Substring(insertPos + 1);
            string styleTag = $"<style type=\"text/css\"><![CDATA[{_css}]]></style>";
            svgContent = before + styleTag + after;
        }

        File.WriteAllText(suggestedFileName, svgContent);
        return suggestedFileName;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input BMP files
            string[] inputPaths = new[]
            {
                "C:\\Images\\sample1.bmp",
                "C:\\Images\\sample2.bmp"
            };

            // Custom CSS to embed in each SVG
            string customCss = @".myClass { fill: red; }";

            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.ChangeExtension(inputPath, ".svg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (Image image = Image.Load(inputPath))
                {
                    var vectorOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = vectorOptions,
                        Callback = new CssEmbeddingCallback(customCss)
                    };

                    image.Save(outputPath, svgOptions);
                }
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
 * 1. When a developer needs to batch‑convert legacy BMP assets to scalable SVG graphics while applying a brand‑specific CSS style for consistent coloring in web applications.
 * 2. When an automation script must generate SVG icons from BMP files and embed a custom stylesheet so the icons inherit theme colors defined in a CSS file.
 * 3. When a reporting tool requires vector‑based diagrams derived from BMP screenshots, with embedded CSS to control stroke and fill properties without external style sheets.
 * 4. When a content management system imports user‑uploaded BMP images and stores them as SVG files that already contain a predefined CSS class for responsive styling.
 * 5. When a desktop application processes a set of BMP maps and outputs SVG maps with an inline style block to enforce map element styles across different browsers.
 */