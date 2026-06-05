using System;
using System.IO;
using System.Net.Http;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Converts a CMX image obtained from a network stream to PDF and writes it to the provided response stream.
    static void ConvertCmxToPdf(Stream responseStream)
    {
        // Hardcoded source URL and temporary file locations.
        string inputUrl = "http://example.com/sample.cmx";
        string tempCmxPath = Path.Combine(Path.GetTempPath(), "sample.cmx");
        string outputPdfPath = Path.Combine(Path.GetTempPath(), "output.pdf");

        // Download the CMX file to a temporary location.
        using (HttpClient client = new HttpClient())
        using (HttpResponseMessage httpResponse = client.GetAsync(inputUrl).Result)
        using (Stream networkStream = httpResponse.Content.ReadAsStreamAsync().Result)
        using (FileStream fileStream = new FileStream(tempCmxPath, FileMode.Create, FileAccess.Write))
        {
            networkStream.CopyTo(fileStream);
        }

        // Verify that the temporary CMX file exists.
        if (!File.Exists(tempCmxPath))
        {
            Console.Error.WriteLine($"File not found: {tempCmxPath}");
            return;
        }

        // Ensure the output directory exists before any save operation.
        Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

        // Load the CMX image using Aspose.Imaging.
        using (Image cmxImage = Image.Load(tempCmxPath))
        {
            // Prepare PDF save options.
            var pdfOptions = new PdfOptions();

            // Save the image as PDF into a memory stream.
            using (MemoryStream pdfMemory = new MemoryStream())
            {
                cmxImage.Save(pdfMemory, pdfOptions);
                pdfMemory.Position = 0;

                // Write the PDF data to the provided response stream.
                pdfMemory.CopyTo(responseStream);
            }
        }
    }

    static void Main()
    {
        try
        {
            // For demonstration purposes, write the PDF to a file that represents the HTTP response.
            string responseFilePath = "C:\\temp\\response.pdf";

            // Ensure the directory for the response file exists.
            Directory.CreateDirectory(Path.GetDirectoryName(responseFilePath));

            using (FileStream responseStream = new FileStream(responseFilePath, FileMode.Create, FileAccess.Write))
            {
                ConvertCmxToPdf(responseStream);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}