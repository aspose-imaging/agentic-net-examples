// HOW-TO: How To Convert DICOM To TIFF With Otsu Binarization And XMP Metadata In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "input.dcm");
            string outputPath = Path.Combine("Output", "output.tiff");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                image.BinarizeOtsu();

                string xmp = "<x:xmpmeta xmlns:x=\"adobe:ns:meta/\" x:xmptk=\"Aspose.Imaging\"><rdf:RDF xmlns:rdf=\"http://www.w3.org/1999/02/22-rdf-syntax-ns#\"><rdf:Description rdf:about=\"\" xmlns:dc=\"http://purl.org/dc/elements/1.1/\"><dc:description>Otsu threshold applied</dc:description></rdf:Description></rdf:RDF></x:xmpmeta>";
                byte[] xmpBytes = System.Text.Encoding.UTF8.GetBytes(xmp);
                image.XmpData = new Aspose.Imaging.Xmp.XmpPacketWrapper(xmpBytes);

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
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
 * 1. When a medical imaging application needs to transform DICOM scans into high‑contrast TIFF files for archival while recording the processing step in XMP metadata.
 * 2. When a radiology workflow requires automated binarization of DICOM images using Otsu’s method before exporting them to TIFF for downstream analysis.
 * 3. When a developer wants to embed processing history into image files by adding XMP tags after applying Otsu threshold to DICOM data.
 * 4. When converting DICOM images to a universally supported format like TIFF for integration with non‑medical software, while preserving metadata about the transformation.
 * 5. When building a C# service that batch‑processes DICOM files, applies Otsu binarization, tags them with XMP descriptions, and saves the results as TIFF for compliance reporting.
 */
