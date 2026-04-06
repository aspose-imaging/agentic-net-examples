using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputPaths = new string[]
        {
            @"C:\Images\img1.jpg",
            @"C:\Images\img2.jpg",
            @"C:\Images\img3.jpg"
        };

        // Hardcoded output PDF file
        string outputPdfPath = @"C:\Output\combined.pdf";

        // Temporary folder for intermediate WEBP files
        string tempWebpFolder = @"C:\Temp\Webp";

        // Ensure the temporary folder exists
        Directory.CreateDirectory(tempWebpFolder);

        // List to hold paths of generated WEBP files
        var webpPaths = new string[inputPaths.Length];

        for (int i = 0; i < inputPaths.Length; i++)
        {
            string inputPath = inputPaths[i];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load JPG image
            using (Image jpgImage = Image.Load(inputPath))
            {
                // Determine WEBP output path
                string webpFileName = Path.GetFileNameWithoutExtension(inputPath) + ".webp";
                string webpPath = Path.Combine(tempWebpFolder, webpFileName);

                // Save as WEBP using default options
                jpgImage.Save(webpPath, new WebPOptions());

                // Store the WEBP path for later PDF creation
                webpPaths[i] = webpPath;
            }
        }

        // Create a multipage image from the WEBP files
        using (Image pdfImage = Image.Create(webpPaths))
        {
            // Ensure output directory exists (unconditionally)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Save the multipage image as a PDF document
            pdfImage.Save(outputPdfPath, new PdfOptions());
        }
    }
}