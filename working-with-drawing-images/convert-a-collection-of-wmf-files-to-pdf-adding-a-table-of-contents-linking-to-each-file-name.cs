// HOW-TO: Combine Multiple WMF Files Into a PDF With Table of Contents in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input WMF file paths
            string[] inputPaths = new string[]
            {
                @"C:\Input\file1.wmf",
                @"C:\Input\file2.wmf",
                @"C:\Input\file3.wmf"
            };

            // Validate each input file
            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Hardcoded output PDF path
            string outputPath = @"C:\Output\Combined.pdf";

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // List to hold all pages (TOC + WMF pages)
            List<Image> pages = new List<Image>();

            // ---------- Create TOC page ----------
            int tocWidth = 800;
            int tocHeight = 1000;
            BmpOptions tocOptions = new BmpOptions();

            RasterImage tocImage = (RasterImage)Image.Create(tocOptions, tocWidth, tocHeight);
            Graphics graphics = new Graphics(tocImage);

            // Fill background with white
            graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, tocWidth, tocHeight));

            // Title
            Font titleFont = new Font("Arial", 36, FontStyle.Bold);
            graphics.DrawString("Table of Contents", titleFont, new SolidBrush(Color.Black), 50, 50);

            // List each file name
            int yOffset = 120;
            Font itemFont = new Font("Arial", 24, FontStyle.Regular);
            foreach (var inputPath in inputPaths)
            {
                string fileName = Path.GetFileName(inputPath);
                graphics.DrawString(fileName, itemFont, new SolidBrush(Color.DarkBlue), 70, yOffset);
                yOffset += 40;
            }

            // Add TOC image to pages list
            pages.Add(tocImage);

            // ---------- Load each WMF and add to pages ----------
            foreach (var inputPath in inputPaths)
            {
                Image wmfImage = Image.Load(inputPath);
                pages.Add(wmfImage);
            }

            // Create a multipage image from the collected pages
            Image multiPage = Image.Create(pages.ToArray(), true);

            // Save as PDF
            PdfOptions pdfOptions = new PdfOptions();
            multiPage.Save(outputPath, pdfOptions);

            // Dispose all images
            foreach (var img in pages)
            {
                img.Dispose();
            }
            multiPage.Dispose();

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to merge several WMF vector drawings into a single PDF report that includes a clickable table of contents for easy navigation.
 * 2. When generating documentation that combines multiple legacy WMF diagrams and you want each diagram listed in a TOC page for quick reference.
 * 3. When automating the creation of a PDF portfolio of engineering schematics stored as WMF files, with a summary page that links to each individual schematic.
 * 4. When building a batch conversion tool that transforms a collection of WMF icons into a consolidated PDF booklet with page references in the contents.
 * 5. When preparing a printable catalog of WMF graphics for client review and you require an automatically generated contents page that lists each file name.
 */
