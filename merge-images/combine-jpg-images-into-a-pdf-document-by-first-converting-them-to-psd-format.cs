using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };
        // Array to hold corresponding PSD file paths
        string[] psdPaths = new string[inputPaths.Length];

        // Process each JPG image
        for (int i = 0; i < inputPaths.Length; i++)
        {
            string inputPath = inputPaths[i];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine PSD output path (same folder, same name with .psd extension)
            string psdPath = Path.ChangeExtension(inputPath, ".psd");
            psdPaths[i] = psdPath;

            // Ensure output directory exists for PSD file
            Directory.CreateDirectory(Path.GetDirectoryName(psdPath) ?? ".");

            // Load JPG and save as PSD using default PsdOptions
            using (Image image = Image.Load(inputPath))
            {
                var psdOptions = new PsdOptions();
                image.Save(psdPath, psdOptions);
            }
        }

        // Define final PDF output path
        string outputPdfPath = "combined.pdf";

        // Ensure output directory exists for PDF file
        Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath) ?? ".");

        // Create a multipage image from the generated PSD files
        using (Image multipageImage = Image.Create(psdPaths))
        {
            // Save the multipage image as a PDF document
            var pdfOptions = new PdfOptions();
            multipageImage.Save(outputPdfPath, pdfOptions);
        }
    }
}