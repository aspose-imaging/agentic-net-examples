using System;
using System.IO;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDir = "InputImages";
        string outputDir = "CanvasOutputs";
        string finalHtmlPath = Path.Combine(outputDir, "CombinedCanvas.html");

        // Ensure input directory exists (create if missing)
        if (!Directory.Exists(inputDir))
        {
            Directory.CreateDirectory(inputDir);
            Console.WriteLine($"Input directory created at: {inputDir}. Add JPEG files and rerun.");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        // Collect all JPEG files (both .jpg and .jpeg)
        string[] jpgFiles = Directory.GetFiles(inputDir, "*.jpg");
        string[] jpegFiles = Directory.GetFiles(inputDir, "*.jpeg");
        string[] allFiles = new string[jpgFiles.Length + jpegFiles.Length];
        jpgFiles.CopyTo(allFiles, 0);
        jpegFiles.CopyTo(allFiles, jpgFiles.Length);

        var sb = new StringBuilder();

        foreach (string inputPath in allFiles)
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare canvas output path
            string canvasFileName = Path.GetFileNameWithoutExtension(inputPath) + ".html";
            string canvasPath = Path.Combine(outputDir, canvasFileName);

            // Ensure directory for canvas file exists
            Directory.CreateDirectory(Path.GetDirectoryName(canvasPath));

            // Load JPEG image and save as HTML5 Canvas (only the canvas tag)
            using (Image image = Image.Load(inputPath))
            {
                var options = new Html5CanvasOptions
                {
                    FullHtmlPage = false
                };
                image.Save(canvasPath, options);
            }

            // Append canvas tag to the combined HTML
            string canvasTag = File.ReadAllText(canvasPath);
            sb.AppendLine(canvasTag);
        }

        // Build the final HTML page containing all canvases
        string finalHtml = @"<!DOCTYPE html>
<html>
<head>
    <meta charset=""UTF-8"">
    <title>Combined Canvases</title>
</head>
<body>
" + sb.ToString() + @"
</body>
</html>";

        // Ensure directory for final HTML exists
        Directory.CreateDirectory(Path.GetDirectoryName(finalHtmlPath));

        // Write the combined HTML page
        File.WriteAllText(finalHtmlPath, finalHtml);

        Console.WriteLine($"Combined HTML page created at: {finalHtmlPath}");
    }
}