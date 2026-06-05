using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths for single‑page conversion
            string singleInputPath = "single_page.cmx";
            string singleOutputPath = "single_page.tif";

            // Hardcoded input and output paths for multi‑page conversion
            string multiInputPath = "multi_page.cmx";
            string multiOutputPath = "multi_page.tif";

            // Validate input files
            if (!File.Exists(singleInputPath))
            {
                Console.Error.WriteLine($"File not found: {singleInputPath}");
                return;
            }
            if (!File.Exists(multiInputPath))
            {
                Console.Error.WriteLine($"File not found: {multiInputPath}");
                return;
            }

            // Ensure output directories exist (guard against null/empty directory name)
            string singleOutDir = Path.GetDirectoryName(singleOutputPath);
            if (!string.IsNullOrWhiteSpace(singleOutDir))
            {
                Directory.CreateDirectory(singleOutDir);
            }

            string multiOutDir = Path.GetDirectoryName(multiOutputPath);
            if (!string.IsNullOrWhiteSpace(multiOutDir))
            {
                Directory.CreateDirectory(multiOutDir);
            }

            // ---------- Single‑page CMX → TIFF ----------
            using (CmxImage cmxSingle = (CmxImage)Image.Load(singleInputPath))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                cmxSingle.Save(singleOutputPath, tiffOptions);
            }

            // Verify single‑page TIFF frames
            using (TiffImage tiffSingle = (TiffImage)Image.Load(singleOutputPath))
            {
                Console.WriteLine($"Single‑page TIFF frames: {tiffSingle.Frames.Length}");
            }

            // ---------- Multi‑page CMX → TIFF ----------
            using (CmxImage cmxMulti = (CmxImage)Image.Load(multiInputPath))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                // Preserve all pages; no MultiPageOptions needed for full export
                cmxMulti.Save(multiOutputPath, tiffOptions);
            }

            // Verify multi‑page TIFF frames
            using (TiffImage tiffMulti = (TiffImage)Image.Load(multiOutputPath))
            {
                Console.WriteLine($"Multi‑page TIFF frames: {tiffMulti.Frames.Length}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}