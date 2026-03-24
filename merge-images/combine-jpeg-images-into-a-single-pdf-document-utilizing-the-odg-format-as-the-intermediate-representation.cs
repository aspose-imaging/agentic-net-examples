using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPEG files
        string[] jpegInputs = new[]
        {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.jpg",
            @"C:\Images\photo3.jpg"
        };

        // Temporary folder for intermediate ODG files
        string odgTempFolder = @"C:\Temp\OdgIntermediate";
        Directory.CreateDirectory(odgTempFolder); // ensure folder exists

        // Convert each JPEG to ODG
        string[] odgFiles = new string[jpegInputs.Length];
        for (int i = 0; i < jpegInputs.Length; i++)
        {
            string jpegPath = jpegInputs[i];
            if (!File.Exists(jpegPath))
            {
                Console.Error.WriteLine($"File not found: {jpegPath}");
                return;
            }

            // Load JPEG image
            using (Image jpegImage = Image.Load(jpegPath))
            {
                // Prepare ODG output path
                string odgPath = Path.Combine(odgTempFolder, $"page{i + 1}.odg");
                odgFiles[i] = odgPath;

                // Ensure directory for ODG exists (already created above)
                Directory.CreateDirectory(Path.GetDirectoryName(odgPath));

                // Save as ODG (vector format)
                jpegImage.Save(odgPath);
            }
        }

        // Create a multipage ODG image from the intermediate files
        using (Image multipageOdg = Image.Create(odgFiles))
        {
            // Hard‑coded final PDF output path
            string pdfOutputPath = @"C:\Output\CombinedImages.pdf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(pdfOutputPath));

            // Configure PDF options with ODG rasterization
            PdfOptions pdfOptions = new PdfOptions();
            OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = multipageOdg.Size
            };
            pdfOptions.VectorRasterizationOptions = rasterOptions;

            // Save the multipage ODG as a single PDF document
            multipageOdg.Save(pdfOutputPath, pdfOptions);
        }
    }
}