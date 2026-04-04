using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Hard‑coded input folder containing WMF files and output folder for PDFs.
    // No argument validation is performed as per the safety rules.
    static void Main()
    {
        // Input directory (change as needed)
        string inputFolder = @"C:\WmfInput";
        // Output directory (change as needed)
        string outputFolder = @"C:\PdfOutput";

        // Ensure the output directory exists before any save operation.
        Directory.CreateDirectory(outputFolder);

        // Collection of WMF file names to process.
        // Add or remove file names as required.
        string[] wmfFiles = new[]
        {
            "FirstImage.wmf",
            "SecondImage.wmf",
            "ThirdImage.wmf"
        };

        // Create a simple table‑of‑contents text file that lists the generated PDFs.
        // This file can be opened alongside the PDFs for reference.
        string tocPath = Path.Combine(outputFolder, "TableOfContents.txt");
        using (var tocWriter = new StreamWriter(tocPath))
        {
            tocWriter.WriteLine("Table of Contents");
            tocWriter.WriteLine("=================");
            tocWriter.WriteLine();

            foreach (string wmfFileName in wmfFiles)
            {
                string inputPath = Path.Combine(inputFolder, wmfFileName);

                // Verify that the input WMF file exists.
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Derive the output PDF path.
                string pdfFileName = Path.GetFileNameWithoutExtension(wmfFileName) + ".pdf";
                string outputPath = Path.Combine(outputFolder, pdfFileName);

                // Ensure the directory for the output file exists (already created above,
                // but the rule requires the call before each save).
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WMF image.
                using (Image wmfImage = Image.Load(inputPath))
                {
                    // Prepare PDF save options.
                    var pdfOptions = new PdfOptions
                    {
                        // Optional: set page size to match the source image size.
                        PageSize = wmfImage.Size,
                        // Optional: keep original resolution.
                        UseOriginalImageResolution = true,
                        // Configure core PDF options (e.g., enable bookmarks outline level).
                        PdfCoreOptions = new Aspose.Imaging.FileFormats.Pdf.PdfCoreOptions
                        {
                            // BookmarksOutlineLevel = 1 would show a bookmark for each page,
                            // but since each PDF contains a single page, this creates a simple outline.
                            BookmarksOutlineLevel = 1
                        }
                    };

                    // Save the WMF as a PDF.
                    wmfImage.Save(outputPath, pdfOptions);
                }

                // Write an entry to the TOC file.
                tocWriter.WriteLine($"{Path.GetFileNameWithoutExtension(wmfFileName)} -> {pdfFileName}");
            }

            tocWriter.WriteLine();
            tocWriter.WriteLine("End of Table of Contents");
        }

        Console.WriteLine("Conversion completed. PDFs and TableOfContents.txt are located at:");
        Console.WriteLine(outputFolder);
    }
}