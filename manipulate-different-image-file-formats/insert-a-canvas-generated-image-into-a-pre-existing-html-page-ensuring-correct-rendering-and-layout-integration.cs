using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string vectorPath = @"Sample.svg";
        string existingHtmlPath = @"ExistingPage.html";
        string outputHtmlPath = @"ResultPage.html";

        // Verify input files exist
        if (!File.Exists(vectorPath))
        {
            Console.Error.WriteLine($"File not found: {vectorPath}");
            return;
        }
        if (!File.Exists(existingHtmlPath))
        {
            Console.Error.WriteLine($"File not found: {existingHtmlPath}");
            return;
        }

        // Load the vector image (SVG) that will be converted to a Canvas tag
        using (var image = Image.Load(vectorPath))
        {
            // Prepare options to generate only the Canvas tag (no full HTML page)
            var canvasOptions = new Html5CanvasOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions(),
                FullHtmlPage = false
            };

            // Save the Canvas HTML to a memory stream
            using (var ms = new MemoryStream())
            {
                image.Save(ms, canvasOptions);
                ms.Position = 0;
                string canvasHtml = new StreamReader(ms).ReadToEnd();

                // Read the existing HTML page
                string existingHtml = File.ReadAllText(existingHtmlPath);

                // Insert the Canvas HTML before the closing </body> tag; if not found, append at the end
                string insertionPoint = "</body>";
                string combinedHtml;
                if (existingHtml.IndexOf(insertionPoint, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    combinedHtml = existingHtml.Replace(insertionPoint, canvasHtml + insertionPoint);
                }
                else
                {
                    combinedHtml = existingHtml + canvasHtml;
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputHtmlPath));

                // Write the combined HTML to the output file
                File.WriteAllText(outputHtmlPath, combinedHtml);
            }
        }
    }
}