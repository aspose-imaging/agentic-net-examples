using System;
using System.IO;
using System.Net;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input BMP file path
        string inputPath = @"C:\temp\sample.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Set up a simple HTTP listener to serve the PDF
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:8080/");
        listener.Start();
        Console.WriteLine("Listening on http://localhost:8080/ ...");

        try
        {
            while (true)
            {
                // Wait for an incoming HTTP request
                HttpListenerContext context = listener.GetContext();
                HttpListenerResponse response = context.Response;

                // Prepare response headers for a PDF file
                response.ContentType = "application/pdf";
                response.AddHeader("Content-Disposition", "attachment; filename=\"output.pdf\"");

                // Load the BMP image and convert it to PDF directly into the response stream
                using (Image image = Image.Load(inputPath))
                {
                    PdfOptions pdfOptions = new PdfOptions();

                    // The response stream is guaranteed to exist; no need for directory creation
                    // Save the image as PDF into the HTTP response stream
                    image.Save(response.OutputStream, pdfOptions);
                }

                // Complete the response
                response.OutputStream.Close();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            listener.Stop();
        }
    }
}