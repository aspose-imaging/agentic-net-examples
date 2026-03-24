using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] jpgPaths = new string[]
        {
            @"C:\Images\img1.jpg",
            @"C:\Images\img2.jpg",
            @"C:\Images\img3.jpg"
        };

        // Verify each input file exists
        foreach (string jpgPath in jpgPaths)
        {
            if (!File.Exists(jpgPath))
            {
                Console.Error.WriteLine($"File not found: {jpgPath}");
                return;
            }
        }

        // Folder to store intermediate WEBP files
        string webpFolder = @"C:\Temp\Webp";
        Directory.CreateDirectory(webpFolder); // ensure folder exists

        // Convert each JPG to WEBP
        string[] webpPaths = new string[jpgPaths.Length];
        for (int i = 0; i < jpgPaths.Length; i++)
        {
            string jpgPath = jpgPaths[i];
            string webpPath = Path.Combine(webpFolder, Path.GetFileNameWithoutExtension(jpgPath) + ".webp");

            // Ensure output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(webpPath));

            using (Image image = Image.Load(jpgPath))
            {
                // Save as WEBP using default options
                image.Save(webpPath, new WebPOptions());
            }

            webpPaths[i] = webpPath;
        }

        // Create a multipage image from the WEBP files
        using (Image multipageImage = Image.Create(webpPaths))
        {
            // Output PDF path
            string pdfPath = @"C:\Output\combined.pdf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

            // Save the multipage image as a PDF
            multipageImage.Save(pdfPath, new PdfOptions());
        }
    }
}