using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input BMP files (replace with actual shared folder paths)
        string[] inputPaths = new[]
        {
            @"\\share\images\image1.bmp",
            @"\\share\images\image2.bmp"
        };

        // Hard‑coded output PDF files (replace with desired output locations)
        string[] outputPaths = new[]
        {
            @"C:\output\image1.pdf",
            @"C:\output\image2.pdf"
        };

        // Process each file pair
        for (int i = 0; i < inputPaths.Length && i < outputPaths.Length; i++)
        {
            string inputPath = inputPaths[i];
            string outputPath = outputPaths[i];

            // Input file existence check (no exception throwing)
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (unconditional)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Convert BMP to PDF and stream the result
            ConvertBmpToPdfAndStream(inputPath, outputPath);
        }
    }

    static void ConvertBmpToPdfAndStream(string bmpPath, string pdfPath)
    {
        // Load BMP image using Aspose.Imaging
        using (Image image = Image.Load(bmpPath))
        {
            // Prepare PDF save options
            var pdfOptions = new PdfOptions();

            // Save PDF to file
            image.Save(pdfPath, pdfOptions);

            // Also save PDF to a memory stream to simulate streaming back to a client
            using (var memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, pdfOptions);
                memoryStream.Position = 0;

                // Example: write PDF bytes to standard output (replace with actual response stream in a web app)
                byte[] buffer = new byte[81920];
                int bytesRead;
                while ((bytesRead = memoryStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Console.OpenStandardOutput().Write(buffer, 0, bytesRead);
                }
            }
        }
    }
}