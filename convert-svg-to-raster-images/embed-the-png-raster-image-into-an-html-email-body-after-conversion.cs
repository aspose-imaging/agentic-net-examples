using System;
using System.IO;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.png";
        string outputPath = @"C:\Emails\email.html";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Save the image to a memory stream (PNG format) to obtain raw bytes
            using (var ms = new MemoryStream())
            {
                image.Save(ms, new PngOptions());
                byte[] imageBytes = ms.ToArray();

                // Convert image bytes to Base64 string
                string base64 = Convert.ToBase64String(imageBytes);

                // Build HTML email body with embedded image
                string html = $"<html><body>" +
                              $"<p>Hello,</p>" +
                              $"<img src=\"data:image/png;base64,{base64}\" alt=\"Embedded Image\"/>" +
                              $"</body></html>";

                // Write the HTML to the output file
                File.WriteAllText(outputPath, html, Encoding.UTF8);
            }
        }

        Console.WriteLine("Email HTML with embedded image has been created.");
    }
}