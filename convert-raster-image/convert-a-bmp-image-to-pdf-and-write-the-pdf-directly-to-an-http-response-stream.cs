using System;
using System.IO;
using System.Net;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input BMP file path
            string inputPath = @"C:\temp\sample.bmp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Set up a simple HTTP listener
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();
            Console.WriteLine("Listening on http://localhost:8080/ ...");

            // Process a single request (for demonstration purposes)
            HttpListenerContext context = listener.GetContext();
            ProcessRequest(context, inputPath);

            // Stop the listener after handling the request
            listener.Stop();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ProcessRequest(HttpListenerContext context, string inputPath)
    {
        // Load the BMP image from the hardcoded path
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PDF export options
            PdfOptions pdfOptions = new PdfOptions();

            // Save the image to a memory stream in PDF format
            using (MemoryStream pdfStream = new MemoryStream())
            {
                image.Save(pdfStream, pdfOptions);
                pdfStream.Position = 0;

                // Write the PDF bytes directly to the HTTP response stream
                HttpListenerResponse response = context.Response;
                response.ContentType = "application/pdf";
                response.ContentLength64 = pdfStream.Length;
                pdfStream.CopyTo(response.OutputStream);
                response.OutputStream.Close();
                response.Close();
            }
        }
    }
}