using System;
using System.IO;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input path and password
            string inputPath = "input.jpg";
            string password = "secret";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load JPEG image from a file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (JpegImage jpegImage = new JpegImage(stream))
            {
                // Check digital signature
                bool isSigned = jpegImage.IsDigitalSigned(password);
                Console.WriteLine(isSigned
                    ? "The image is digitally signed."
                    : "The image is NOT digitally signed.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}