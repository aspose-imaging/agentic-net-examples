using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
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
            using (var image = Image.Load(inputPath))
            {
                // Save the image to a memory stream to obtain its byte array
                using (var ms = new MemoryStream())
                {
                    image.Save(ms, new PngOptions());
                    byte[] imageData = ms.ToArray();

                    // Convert image bytes to Base64 string
                    string base64 = Convert.ToBase64String(imageData);

                    // Build HTML email body with embedded image
                    string html = $"<html><body>" +
                                  $"<p>Here is the image:</p>" +
                                  $"<img src=\"data:image/png;base64,{base64}\" alt=\"Embedded Image\" />" +
                                  $"</body></html>";

                    // Write the HTML to the output file
                    File.WriteAllText(outputPath, html);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}