using System;
using System.IO;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDir = Path.Combine(baseDir, "Input");
        string outputDir = Path.Combine(baseDir, "Output");

        // Ensure directories exist
        Directory.CreateDirectory(inputDir);
        Directory.CreateDirectory(outputDir);

        // Get all JPEG files in the input directory
        string[] jpegFiles = Directory.GetFiles(inputDir, "*.jpg");
        string[] jpegFilesAlt = Directory.GetFiles(inputDir, "*.jpeg");
        string[] allJpegFiles = new string[jpegFiles.Length + jpegFilesAlt.Length];
        jpegFiles.CopyTo(allJpegFiles, 0);
        jpegFilesAlt.CopyTo(allJpegFiles, jpegFiles.Length);

        // Process each JPEG file
        foreach (string inputPath in allJpegFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output canvas file path
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string canvasPath = Path.Combine(outputDir, fileNameWithoutExt + ".html");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(canvasPath));

            // Load JPEG image and save as HTML5 canvas (canvas tag only)
            using (Image image = Image.Load(inputPath))
            using (Html5CanvasOptions options = new Html5CanvasOptions { FullHtmlPage = false })
            {
                image.Save(canvasPath, options);
            }
        }

        // Generate a single HTML page that includes all canvases
        string masterHtmlPath = Path.Combine(outputDir, "AllCanvases.html");
        Directory.CreateDirectory(Path.GetDirectoryName(masterHtmlPath));

        StringBuilder htmlBuilder = new StringBuilder();
        htmlBuilder.AppendLine("<!DOCTYPE html>");
        htmlBuilder.AppendLine("<html>");
        htmlBuilder.AppendLine("<head>");
        htmlBuilder.AppendLine("<meta charset=\"UTF-8\">");
        htmlBuilder.AppendLine("<title>All Canvases</title>");
        htmlBuilder.AppendLine("</head>");
        htmlBuilder.AppendLine("<body>");

        // Append each canvas tag to the master HTML
        foreach (string inputPath in allJpegFiles)
        {
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string canvasPath = Path.Combine(outputDir, fileNameWithoutExt + ".html");

            if (File.Exists(canvasPath))
            {
                string canvasTag = File.ReadAllText(canvasPath);
                htmlBuilder.AppendLine(canvasTag);
            }
        }

        htmlBuilder.AppendLine("</body>");
        htmlBuilder.AppendLine("</html>");

        // Write the combined HTML page
        File.WriteAllText(masterHtmlPath, htmlBuilder.ToString());
    }
}