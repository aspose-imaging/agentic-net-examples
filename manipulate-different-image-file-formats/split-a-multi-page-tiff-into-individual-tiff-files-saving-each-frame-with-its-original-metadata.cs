// HOW-TO: Split Multi‑Page TIFF into Separate Files with Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputDir = "output_frames";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                int pageCount = tiff.PageCount;

                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"frame_{i + 1}.tif");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    TiffOptions options = new TiffOptions(TiffExpectedFormat.Default);
                    options.MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1));

                    tiff.Save(outputPath, options);
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
 * 1. When you need to extract each scanned page from a multi‑page TIFF document for individual processing or distribution while keeping the original EXIF and TIFF tags.
 * 2. When a medical imaging system must separate DICOM‑converted TIFF frames into single‑page files for patient‑specific analysis without losing metadata.
 * 3. When an archival workflow requires breaking down large multi‑page TIFFs of historical newspapers into per‑page files for easier indexing and search.
 * 4. When a printing service wants to generate separate TIFF files for each page of a multi‑page artwork to send to different printers while preserving color profiles.
 * 5. When a cloud‑based image‑processing pipeline needs to split uploaded multi‑page TIFFs into individual images for parallel processing, ensuring each output retains its original metadata.
 */
