using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input image, HTML template, temporary canvas, and final output paths
        string inputPath = "input/input.jpg";
        string templatePath = "template/template.html";
        string tempCanvasPath = "output/tempCanvas.html";
        string outputPath = "output/final.html";

        // Validate input image existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Validate template file existence
        if (!File.Exists(templatePath))
        {
            Console.Error.WriteLine($"File not found: {templatePath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(tempCanvasPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Export only the canvas tag (no full HTML page) to a temporary file
        using (Image image = Image.Load(inputPath))
        {
            var options = new Html5CanvasOptions
            {
                FullHtmlPage = false,
                VectorRasterizationOptions = new SvgRasterizationOptions()
            };
            image.Save(tempCanvasPath, options);
        }

        // Read the generated canvas tag
        string canvasTag = File.ReadAllText(tempCanvasPath);

        // Read the existing HTML template
        string templateContent = File.ReadAllText(templatePath);

        // Replace placeholder {{canvas}} with the actual canvas tag
        string result = templateContent.Replace("{{canvas}}", canvasTag);

        // Write the final HTML file with the embedded canvas
        File.WriteAllText(outputPath, result);
    }
}