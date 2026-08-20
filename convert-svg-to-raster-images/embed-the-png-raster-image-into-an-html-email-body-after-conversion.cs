// HOW-TO: Embed PNG Image in HTML Email Body Using C# and Aspose.Imaging (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Emails\email.html";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Save the image to a memory stream to obtain raw bytes
                using (MemoryStream ms = new MemoryStream())
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

/*
 * Real-World Use Cases:
 * 1. When you need to send a PNG logo directly inside an HTML email without attaching separate image files.
 * 2. When an automated reporting system must embed dynamically generated charts as inline images in email notifications.
 * 3. When a marketing application creates personalized newsletters and wants to include product images encoded as Base64 to avoid external image loading.
 * 4. When a C# service prepares transactional emails and must ensure the image renders correctly across email clients that block external resources.
 * 5. When you want to convert any PNG file to a Base64 string and embed it in an HTML template for compliance‑friendly email archiving.
 */
