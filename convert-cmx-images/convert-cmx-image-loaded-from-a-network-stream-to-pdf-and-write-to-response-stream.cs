// HOW-TO: Convert CMX Image From URL To PDF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Net;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input URL and output file path
        string inputUrl = "https://example.com/sample.cmx";
        string outputPath = "C:\\Temp\\output.pdf";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Download the CMX image into a network stream
            using (WebClient webClient = new WebClient())
            using (Stream networkStream = webClient.OpenRead(inputUrl))
            {
                // Load the image from the network stream
                using (Image image = Image.Load(networkStream))
                {
                    // Save the image as PDF to the output file stream
                    using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
                    {
                        image.Save(outputStream, new PdfOptions());
                    }
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
 * 1. When you need to download a CMX vector file from a web service and generate a PDF for client download.
 * 2. When integrating legacy CorelDRAW CMX assets into a web application that serves PDFs to users.
 * 3. When automating batch conversion of network‑hosted CMX diagrams to PDF for archival purposes.
 * 4. When building an API endpoint that receives a CMX URL, converts it to PDF, and streams the result back to the caller.
 * 5. When creating a server‑side process that transforms CMX design files into printable PDF documents without saving intermediate files locally.
 */
