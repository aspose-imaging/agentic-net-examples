using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input BMP file path
        string inputPath = @"C:\temp\input.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Set up a simple HTTP listener
        var listener = new System.Net.HttpListener();
        listener.Prefixes.Add("http://localhost:8080/");
        listener.Start();
        Console.WriteLine("Listening on http://localhost:8080/ ...");

        // Wait for a single request
        var context = listener.GetContext();
        var response = context.Response;
        response.ContentType = "application/pdf";

        // Load BMP image and save as PDF directly to the response stream
        using (Image image = Image.Load(inputPath))
        {
            image.Save(response.OutputStream, new PdfOptions());
        }

        // Complete the response
        response.OutputStream.Close();
        response.Close();

        // Stop the listener
        listener.Stop();
    }
}