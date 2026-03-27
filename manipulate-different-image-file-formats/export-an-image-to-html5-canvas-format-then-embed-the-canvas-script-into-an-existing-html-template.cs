using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input image path
        string inputPath = "Sample.svg";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Hardcoded HTML template path
        string templatePath = "Template.html";
        if (!File.Exists(templatePath))
        {
            Console.Error.WriteLine($"File not found: {templatePath}");
            return;
        }

        // Temporary file to store the canvas tag only
        string canvasTempPath = "CanvasTemp.html";
        Directory.CreateDirectory(Path.GetDirectoryName(canvasTempPath) ?? ".");

        // Load the source image and export only the canvas tag
        using (var image = Image.Load(inputPath))
        {
            var options = new Html5CanvasOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions(),
                FullHtmlPage = false // Export only the <canvas> element
            };
            image.Save(canvasTempPath, options);
        }

        // Read generated canvas HTML
        string canvasHtml = File.ReadAllText(canvasTempPath);

        // Read the existing HTML template
        string templateHtml = File.ReadAllText(templatePath);

        // Replace placeholder {{CANVAS}} with the generated canvas HTML
        string resultHtml = templateHtml.Replace("{{CANVAS}}", canvasHtml);

        // Hardcoded final output path
        string outputPath = "Result.html";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Write the final HTML file
        File.WriteAllText(outputPath, resultHtml);
    }
}