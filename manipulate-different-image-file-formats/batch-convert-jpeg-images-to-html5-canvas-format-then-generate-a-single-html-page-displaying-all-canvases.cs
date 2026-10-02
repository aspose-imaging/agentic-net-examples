// HOW-TO: Batch Convert JPEG Images to HTML5 Canvas HTML Page in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "InputJpeg";
            string outputDir = "OutputHtml";

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add JPEG files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string[] jpgFiles = Directory.GetFiles(inputDir, "*.jpg");
            string[] jpegFiles = Directory.GetFiles(inputDir, "*.jpeg");
            List<string> allFiles = new List<string>();
            allFiles.AddRange(jpgFiles);
            allFiles.AddRange(jpegFiles);

            List<string> canvasFiles = new List<string>();

            foreach (string inputPath in allFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".html");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    using (Html5CanvasOptions options = new Html5CanvasOptions()
                    {
                        Source = new FileCreateSource(outputPath, false)
                    })
                    {
                        image.Save(outputPath, options);
                    }
                }

                canvasFiles.Add(Path.GetFileName(outputPath));
            }

            string masterHtmlPath = Path.Combine(outputDir, "index.html");
            Directory.CreateDirectory(Path.GetDirectoryName(masterHtmlPath));

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html><head><meta charset=\"UTF-8\"><title>Canvas Gallery</title></head><body>");
            foreach (string canvasFile in canvasFiles)
            {
                sb.AppendLine($"<iframe src=\"{canvasFile}\" style=\"border:none; width:100%; height:500px;\"></iframe>");
                sb.AppendLine("<hr/>");
            }
            sb.AppendLine("</body></html>");

            File.WriteAllText(masterHtmlPath, sb.ToString());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to create a web‑based gallery that displays many JPEG photos without loading external image files, you can batch convert them to HTML5 canvas elements and embed them in a single HTML page.
 * 2. When a reporting tool must embed high‑resolution JPEG charts directly into an HTML report for offline viewing, this code converts each chart to a canvas‑based HTML snippet and combines them.
 * 3. When a legacy system stores images as JPEG files but the front‑end requires canvas drawing for pixel‑level manipulation, you can automate the conversion of all stored images to canvas HTML using Aspose.Imaging.
 * 4. When you want to reduce HTTP requests by embedding JPEG content as canvas data in a single HTML file for faster page loads on low‑bandwidth devices, this batch conversion script handles it.
 * 5. When an e‑learning platform needs to generate interactive HTML5 lessons that include multiple JPEG illustrations without relying on external image URLs, the code creates a consolidated HTML page with each illustration rendered on a canvas.
 */
