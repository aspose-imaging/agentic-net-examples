using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] jpgPaths = {
            @"input\image1.jpg",
            @"input\image2.jpg",
            @"input\image3.jpg"
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

        // Directory for temporary APNG files
        string apngDir = @"temp";
        Directory.CreateDirectory(apngDir);

        // Convert each JPG to APNG and store temporary paths
        string[] apngPaths = new string[jpgPaths.Length];
        for (int i = 0; i < jpgPaths.Length; i++)
        {
            string jpgPath = jpgPaths[i];
            string apngPath = Path.Combine(apngDir, $"frame{i + 1}.png");
            apngPaths[i] = apngPath;

            // Ensure output directory exists (already created above)
            Directory.CreateDirectory(Path.GetDirectoryName(apngPath));

            // Load JPG image
            using (Image jpgImage = Image.Load(jpgPath))
            {
                // Save as APNG using default options
                jpgImage.Save(apngPath, new ApngOptions());
            }
        }

        // Create a multipage image from the APNG files
        using (Image multipageImage = Image.Create(apngPaths))
        {
            // Define PDF output path
            string pdfOutputPath = @"output\combined.pdf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(pdfOutputPath));

            // Set PDF options (default options are sufficient)
            PdfOptions pdfOptions = new PdfOptions();

            // Save the multipage image as a PDF document
            multipageImage.Save(pdfOutputPath, pdfOptions);
        }
    }
}