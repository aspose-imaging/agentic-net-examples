using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputImagePath = "input.png";
            string outputHtmlPath = "output/email.html";

            // Validate input file
            if (!File.Exists(inputImagePath))
            {
                Console.Error.WriteLine($"File not found: {inputImagePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputHtmlPath));

            // Load image and convert to PNG bytes
            using (Image image = Image.Load(inputImagePath))
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, new PngOptions());
                byte[] imageBytes = ms.ToArray();
                string base64 = Convert.ToBase64String(imageBytes);

                // Build HTML with embedded image
                string htmlContent = $"<html><body><img src=\"data:image/png;base64,{base64}\" alt=\"Embedded Image\"/></body></html>";

                // Write HTML to file
                File.WriteAllText(outputHtmlPath, htmlContent);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}