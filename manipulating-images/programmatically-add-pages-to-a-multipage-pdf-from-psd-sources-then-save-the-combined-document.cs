using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input PSD files
            string psdPath1 = "Input1.psd";
            string psdPath2 = "Input2.psd";

            // Output PDF file
            string outputPath = "Output/Combined.pdf";

            // Validate input files
            if (!File.Exists(psdPath1))
            {
                Console.Error.WriteLine($"File not found: {psdPath1}");
                return;
            }
            if (!File.Exists(psdPath2))
            {
                Console.Error.WriteLine($"File not found: {psdPath2}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Load PSD images
            using (Image img1 = Image.Load(psdPath1))
            using (Image img2 = Image.Load(psdPath2))
            {
                // Create a multipage image from the loaded PSDs
                Image[] pages = new Image[] { img1, img2 };
                using (Image pdf = Image.Create(pages))
                {
                    // Save as PDF
                    var pdfOptions = new PdfOptions();
                    pdf.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a design team needs to combine several Photoshop PSD files into a single multi‑page PDF portfolio for client approval, a developer can use this C# code with Aspose.Imaging to load each PSD, create a multipage image, and save it as a combined PDF.
 * 2. When an automated publishing workflow must convert layered PSD assets into a paginated PDF brochure, this snippet programmatically loads the PSDs, assembles them as pages, and outputs a ready‑to‑print PDF document.
 * 3. When a web service offers on‑the‑fly PDF generation from uploaded PSD designs, the code demonstrates how to validate file paths, load the PSDs, merge them into a multi‑page PDF, and return the result to the caller.
 * 4. When a batch‑processing tool needs to archive multiple PSD project files as a single searchable PDF file, the example shows how to create a multipage image from the PSD sources and save it efficiently using Aspose.Imaging in .NET.
 * 5. When a digital asset management system must provide a preview PDF that stitches together several PSD mockups into one document, this C# example illustrates the steps to load each PSD, combine them into a PDF, and store the combined file in a designated output folder.
 */