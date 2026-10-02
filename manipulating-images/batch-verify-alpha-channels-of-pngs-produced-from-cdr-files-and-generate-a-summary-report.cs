// HOW-TO: Batch Verify Alpha Channels of PNGs Converted from CDR Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string reportPath = "Output\\AlphaReport.txt";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            string reportDirectory = Path.GetDirectoryName(reportPath);
            if (!string.IsNullOrEmpty(reportDirectory))
            {
                Directory.CreateDirectory(reportDirectory);
            }

            string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr");
            List<string> reportLines = new List<string>();

            foreach (string cdrFile in cdrFiles)
            {
                if (!File.Exists(cdrFile))
                {
                    Console.Error.WriteLine($"File not found: {cdrFile}");
                    return;
                }

                string fileName = Path.GetFileName(cdrFile);
                using (CdrImage cdr = (CdrImage)Image.Load(cdrFile))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        PngOptions pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = new CdrRasterizationOptions
                            {
                                PageWidth = cdr.Width,
                                PageHeight = cdr.Height
                            }
                        };
                        cdr.Save(ms, pngOptions);
                        ms.Position = 0;

                        using (RasterImage png = (RasterImage)Image.Load(ms))
                        {
                            int[] pixels = png.LoadArgb32Pixels(png.Bounds);
                            bool hasAlpha = false;
                            foreach (int argb in pixels)
                            {
                                int a = (argb >> 24) & 0xFF;
                                if (a != 255)
                                {
                                    hasAlpha = true;
                                    break;
                                }
                            }
                            string result = hasAlpha ? "Alpha channel present" : "No alpha channel";
                            reportLines.Add($"{fileName}: {result}");
                        }
                    }
                }
            }

            File.WriteAllLines(reportPath, reportLines);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to ensure that all PNG images generated from CorelDRAW (CDR) files retain correct transparency before publishing them on a website.
 * 2. When a graphics pipeline must automatically scan a folder of CDR files, convert each to PNG, and flag any images with missing or incorrect alpha channels.
 * 3. When you want to create a concise text report listing which converted PNGs have valid alpha information for quality‑control audits.
 * 4. When integrating Aspose.Imaging into a C# build process to validate transparency of assets used in UI mockups or mobile apps.
 * 5. When a batch conversion tool must verify transparency compliance of thousands of design files without manually opening each image.
 */
