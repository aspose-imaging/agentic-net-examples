// HOW-TO: Convert DjVu Pages 5 to 7 Into a Multipage TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\document.djvu";
            string outputPath = "Output\\combined.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            int[] pageIndices = { 4, 5, 6 }; // pages 5‑7 (0‑based)

            string tempDir = Path.Combine(outputDir ?? "", "temp");
            Directory.CreateDirectory(tempDir);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                foreach (int idx in pageIndices)
                {
                    string tempPath = Path.Combine(tempDir, $"page{idx + 1}.tif");
                    TiffOptions tiffOpts = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOpts.MultiPageOptions = new DjvuMultiPageOptions(idx);
                    djvu.Save(tempPath, tiffOpts);
                }
            }

            string firstTemp = Path.Combine(tempDir, $"page{pageIndices[0] + 1}.tif");
            using (TiffImage combined = (TiffImage)Image.Load(firstTemp))
            {
                for (int i = 1; i < pageIndices.Length; i++)
                {
                    string tempPath = Path.Combine(tempDir, $"page{pageIndices[i] + 1}.tif");
                    using (TiffImage pageImg = (TiffImage)Image.Load(tempPath))
                    {
                        combined.AddFrame(TiffFrame.CopyFrame(pageImg.ActiveFrame));
                    }
                }

                combined.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
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
 * 1. When you need to extract pages 5‑7 from a DjVu document and bundle them into a single multipage TIFF for archival or printing.
 * 2. When a legacy system only accepts TIFF files, you can convert selected DjVu pages to a combined TIFF to integrate the content without manual conversion.
 * 3. When creating a searchable image archive, extracting specific DjVu pages and saving them as a multipage TIFF simplifies indexing and OCR processing.
 * 4. When generating a compact preview for a legal case, converting the relevant DjVu pages into one TIFF file reduces file handling and sharing overhead.
 * 5. When automating batch processing of scanned documents, this code lets you programmatically select DjVu pages and produce a multipage TIFF for downstream workflows such as compression or watermarking.
 */
